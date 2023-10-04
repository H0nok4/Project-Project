using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConfigType
{
    public partial class DataManager : Singleton<DataManager>
    {
        public List<NPCBaseDefine> NPCBaseDefineList = new List<NPCBaseDefine>();
        public Dictionary<int, NPCBaseDefine> NPCBaseDefineDic = new Dictionary<int, NPCBaseDefine>();
        public NPCBaseDefine GetNPCBaseDefineByID(int ID)
        {
            return NPCBaseDefineDic[ID];
        }

        public List<PokeGirlAttributeBaseDefine> PokeGirlAttributeBaseDefineList = new List<PokeGirlAttributeBaseDefine>();
        public Dictionary<int, PokeGirlAttributeBaseDefine> PokeGirlAttributeBaseDefineDic = new Dictionary<int, PokeGirlAttributeBaseDefine>();
        public PokeGirlAttributeBaseDefine GetPokeGirlAttributeBaseDefineByID(int ID)
        {
            return PokeGirlAttributeBaseDefineDic[ID];
        }

        public List<PokeGirlBaseDefine> PokeGirlBaseDefineList = new List<PokeGirlBaseDefine>();
        public Dictionary<int, PokeGirlBaseDefine> PokeGirlBaseDefineDic = new Dictionary<int, PokeGirlBaseDefine>();
        public PokeGirlBaseDefine GetPokeGirlBaseDefineByID(int ID)
        {
            return PokeGirlBaseDefineDic[ID];
        }

        public List<SkillBaseDefine> SkillBaseDefineList = new List<SkillBaseDefine>();
        public Dictionary<int, SkillBaseDefine> SkillBaseDefineDic = new Dictionary<int, SkillBaseDefine>();
        public SkillBaseDefine GetSkillBaseDefineByID(int ID)
        {
            return SkillBaseDefineDic[ID];
        }

        public void InitConfigs()
        {
            string ConfigPath = "Assets/Resources/Config/xml/";
            FileStream NPCBaseStream = File.OpenRead(ConfigPath + "NPCBase.xml");
            XmlSerializer NPCBaseDefineserializer = new XmlSerializer(typeof(List<NPCBaseDefine>));
            NPCBaseDefineList = (List<NPCBaseDefine>)NPCBaseDefineserializer.Deserialize(NPCBaseStream);
            FileStream PokeGirlAttributeBaseStream = File.OpenRead(ConfigPath + "PokeGirlAttributeBase.xml");
            XmlSerializer PokeGirlAttributeBaseDefineserializer = new XmlSerializer(typeof(List<PokeGirlAttributeBaseDefine>));
            PokeGirlAttributeBaseDefineList = (List<PokeGirlAttributeBaseDefine>)PokeGirlAttributeBaseDefineserializer.Deserialize(PokeGirlAttributeBaseStream);
            FileStream PokeGirlBaseStream = File.OpenRead(ConfigPath + "PokeGirlBase.xml");
            XmlSerializer PokeGirlBaseDefineserializer = new XmlSerializer(typeof(List<PokeGirlBaseDefine>));
            PokeGirlBaseDefineList = (List<PokeGirlBaseDefine>)PokeGirlBaseDefineserializer.Deserialize(PokeGirlBaseStream);
            FileStream SkillBaseStream = File.OpenRead(ConfigPath + "SkillBase.xml");
            XmlSerializer SkillBaseDefineserializer = new XmlSerializer(typeof(List<SkillBaseDefine>));
            SkillBaseDefineList = (List<SkillBaseDefine>)SkillBaseDefineserializer.Deserialize(SkillBaseStream);
            InitDictionary();
        }

        public void InitDictionary()
        {
            foreach (var i in NPCBaseDefineList)
            {
                NPCBaseDefineDic.Add(i.ID, i);
            }

            foreach (var i in PokeGirlAttributeBaseDefineList)
            {
                PokeGirlAttributeBaseDefineDic.Add(i.ID, i);
            }

            foreach (var i in PokeGirlBaseDefineList)
            {
                PokeGirlBaseDefineDic.Add(i.ID, i);
            }

            foreach (var i in SkillBaseDefineList)
            {
                SkillBaseDefineDic.Add(i.ID, i);
            }
        }
    }
}