using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsvParser {
    class Program {
        //临时，等完善后打包成程序去运行的话，需要改成相对路径
        static string _csvDir = @"..\..\..\..\..\Table"; // 指定CSV文件所在目录
        static string _configTypeCSDir = @"..\..\..\..\..\Output\ConfigType.cs";
        static string _outputDir = @"..\..\..\..\..\Output"; // 指定输出目录
        static string _outputXMLDir = @"..\..\..\..\..\Output\xml";// 指定XML输出目录
        static string _gameXMLDir = @"..\..\..\..\..\..\Assets\Resources\Config\xml\";//游戏的配置目录
        static string _gameConfigTypeDir = @"..\..\..\..\..\..\Assets\Resources\Config\"; //游戏的配置代码目录
        static void Main(string[] args) {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            //先生成Type的文件
            GenerateConfigTypeScriptFile();

            //根据生成的Type文件，使用Roslyn来生成对应的List数据
            GenerateData();

            //将生成出来的代码和XML文件拷贝到游戏工程中
            CopyToGameProject();
        }

        private static void CopyToGameProject()
        {
            //先删除游戏工程中的文件
            if (Directory.Exists(_gameXMLDir))
            {
                Directory.Delete(_gameXMLDir,true);
            }

            if (File.Exists(_gameConfigTypeDir + "ConfigType.cs"))
            {
                File.Delete(_gameConfigTypeDir + "ConfigType.cs");
            }

            //拷贝文件
            Directory.CreateDirectory(_gameXMLDir);
            foreach (var file in Directory.GetFiles(_outputXMLDir))
            {
                File.Copy(file, _gameXMLDir + Path.GetFileName(file));
            }

            Directory.CreateDirectory(_gameConfigTypeDir);
            File.Copy(_configTypeCSDir,_gameConfigTypeDir + "ConfigType.cs");
        }

        static void GenerateConfigTypeScriptFile()
        {
            //CSV表的第一行为数据类型
            //CSV表的第二行为字段名
            //CSV表的第三行为注释
            //CSV表的第四行为若未填写数据时，使用的默认值
            //CSV表的第五行开始为数据

            List<ClassDeclarationSyntax> classes = new List<ClassDeclarationSyntax>();

            foreach (string csvFile in Directory.GetFiles(_csvDir, "*.csv")) {
                string className = Path.GetFileNameWithoutExtension(csvFile);
                var csvFileInstance = CSVFile.ReadCSVFile(csvFile);
                // 解析CSV文件
                List<string> types = csvFileInstance.Data[0];
                List<string> names = csvFileInstance.Data[1];
                List<string> comments = csvFileInstance.Data[2];

                // 生成类的属性
                List<PropertyDeclarationSyntax> properties = new List<PropertyDeclarationSyntax>();
                for (int i = 0; i < types.Count; i++) {
                    if (!string.IsNullOrEmpty(types[i])) {
                        string type = types[i];
                        string name = names[i];
                        string comment = comments[i];

                        // 添加注释
                        SyntaxTriviaList triviaList = SyntaxFactory.ParseTrailingTrivia($"// {comment} \n");

                        // 添加属性
                        PropertyDeclarationSyntax property = SyntaxFactory
                            .PropertyDeclaration(GetTypeSyntax(type), name)
                            .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                            .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                            .WithTrailingTrivia(triviaList);

                        properties.Add(property);
                    }
                }

                // 生成类
                ClassDeclarationSyntax classDecl = SyntaxFactory.ClassDeclaration(className)
                    .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                    .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(properties))
                    .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);

                classes.Add(classDecl);
            }

            // 生成输出文件
            CompilationUnitSyntax output = SyntaxFactory.CompilationUnit()
                .WithUsings(SyntaxFactory.List(new[]
                {
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")),
                    SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Linq"))
                }))
                .WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("ConfigType")).WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(classes))))
                .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);

            string outputFile = Path.Combine(_outputDir, "ConfigType.cs");
            using (var writer = new StreamWriter(outputFile)) {
                output.NormalizeWhitespace().WriteTo(writer);
            }

            Console.WriteLine($"已生成输出文件：{outputFile}");
        }

        static void GenerateData() {
            //通过Roslyn加载ConfigType.cs的所有的类，生成对应类的数值
            var configType = File.ReadAllText(_configTypeCSDir);
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(configType);
            CSharpCompilation compilation = CSharpCompilation.Create("MyCompilation")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(System.Linq.EnumerableQuery).Assembly.Location))
                .AddSyntaxTrees(syntaxTree);
            using (var ms = new MemoryStream()) {
                var result = compilation.Emit(ms);
                if (!result.Success) {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                                               diagnostic.IsWarningAsError ||
                                                                      diagnostic.Severity == DiagnosticSeverity.Error);
                    foreach (Diagnostic diagnostic in failures) {
                        Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                    return;
                }

                ms.Seek(0, SeekOrigin.Begin);

                Assembly assembly = Assembly.Load(ms.ToArray());

                 var files = Directory.GetFiles(_csvDir, "*.csv");


                foreach (string csvFile in Directory.GetFiles(_csvDir, "*.csv")) {
                    var csvFileInstance = CSVFile.ReadCSVFile(csvFile);
                    //读取CSV文件，然后再在ConfigType.cs中找到对应的类，然后生成对应的数据
                    string className = Path.GetFileNameWithoutExtension(csvFile);

                    Type classType = assembly.GetType("ConfigType." + className);


                    if (classType != null) {
                        List<object> obj = new List<object>();
                        for (int i = 4; i < csvFileInstance.Data.Count; i++) {
                            //每一行都代表一个实例
                            object instance = Activator.CreateInstance(classType);
                            var typeName = csvFileInstance.Data[1];
                            for (int j = 0; j < typeName.Count; j++) {
                                FieldInfo property = classType.GetField(typeName[j]);
                                if (!string.IsNullOrEmpty(csvFileInstance.Data[i][j]))
                                {
                                    //有填值，用填的值
                                    property.SetValue(instance, Convert.ChangeType(csvFileInstance.Data[i][j], property.FieldType));
      
                                }
                                else
                                {
                                    //没填值，尝试用默认值
                                    if (!string.IsNullOrEmpty(csvFileInstance.Data[3][j])) {
                                        //使用默认值
                                        property.SetValue(instance, Convert.ChangeType(csvFileInstance.Data[3][j], property.FieldType));
                                    }
                                    else
                                    {
                                        Console.WriteLine($"没有找到对应的默认值，{className}的{typeName[j]}，使用类型的默认值");
                                        object defaultValue = Activator.CreateInstance(property.FieldType);
                                        property.SetValue(instance, Convert.ChangeType(defaultValue, property.FieldType));
                                    }
                                }

                            }

                            obj.Add(instance);
                        }

                        //序列化后写入文件
                        XmlSerializer serializer = new XmlSerializer(obj.GetType(), new Type[] { classType });

                        using (MemoryStream xmlMs = new MemoryStream()) {
                            using (XmlWriter writer = XmlWriter.Create(xmlMs, new XmlWriterSettings() { Indent = true, IndentChars = "\t" })) {
                                serializer.Serialize(writer, obj);
                                string xml = writer.ToString();
                                if (!Directory.Exists(_outputXMLDir)) {
                                    Directory.CreateDirectory(_outputXMLDir);
                                }

                                File.WriteAllBytes(_outputXMLDir + $"//{className}.xml", xmlMs.ToArray());
                            }
                        }

                    }
                    else {
                        Console.WriteLine("没有在ConfigType.cs中找到对应的类型数据");
                    }

                }

            }

            Console.WriteLine("已将生成了对应的XML数据");
        }

        static TypeSyntax GetTypeSyntax(string type) {
            switch (type.ToLower()) {
                case "string":
                    return SyntaxFactory.ParseTypeName("string");
                case "int32":
                    return SyntaxFactory.ParseTypeName("int");
                case "float":
                    return SyntaxFactory.ParseTypeName("float");
                case "bool":
                    return SyntaxFactory.ParseTypeName("bool");
                default:
                    throw new ArgumentException($"Unknown type: {type}");
            }
        }
    }

    public class CSVFile
    {
        public string FileName;

        public List<List<string>> Data = new List<List<string>>();

        public string GetData(int row, int col)
        {
            return Data[row][col];
        }

        public List<string> GetRow(int sheet, int row)
        {
            return Data[row];
        }

        public static CSVFile ReadCSVFile(string path)
        {
            CSVFile csvFile = new CSVFile();

            csvFile.FileName = Path.GetFileNameWithoutExtension(path);
            csvFile.Data = new List<List<string>>();

            var dataArray = File.ReadAllLines(path,Encoding.GetEncoding("GB2312"));

            foreach (var data in dataArray) {            
                //WPS会把中文变为GB2312，很烦,把WPS的妈妈偷走，这边手动转一下UTF8
                byte[] gb2312Bytes = Encoding.GetEncoding("GB2312").GetBytes(data);
                byte[] utf8Bytes = Encoding.Convert(Encoding.GetEncoding("GB2312"), Encoding.UTF8, gb2312Bytes);

                var splitData = Encoding.UTF8.GetString(utf8Bytes).Split(',');
                
                csvFile.Data.Add(splitData.ToList());
            }

            return csvFile;
        }
    }
}