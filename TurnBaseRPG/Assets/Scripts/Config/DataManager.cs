using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConfigType
{
    public partial class DataManager
    {
        public List<PokeGirlAttributeBase> PokeGirlAttributeBaseList = new List<PokeGirlAttributeBase>();
        public Dictionary<int, PokeGirlAttributeBase> PokeGirlAttributeBaseDic = new Dictionary<int, PokeGirlAttributeBase>();
        public PokeGirlAttributeBase GetPokeGirlAttributeBaseByID(int ID)
        {
            return PokeGirlAttributeBaseDic[ID];
        }

        public List<PokeGirlBase> PokeGirlBaseList = new List<PokeGirlBase>();
        public Dictionary<int, PokeGirlBase> PokeGirlBaseDic = new Dictionary<int, PokeGirlBase>();
        public PokeGirlBase GetPokeGirlBaseByID(int ID)
        {
            return PokeGirlBaseDic[ID];
        }

        public void InitConfigs()
        {
            string ConfigPath = "Resources/Config";
            FileStream PokeGirlAttributeBaseStream = File.OpenRead(ConfigPath + "PokeGirlAttributeBase.xml");
            XmlSerializer PokeGirlAttributeBaseserializer = new XmlSerializer(typeof(List<PokeGirlAttributeBase>));
            PokeGirlAttributeBaseList = (List<PokeGirlAttributeBase>)PokeGirlAttributeBaseserializer.Deserialize(PokeGirlAttributeBaseStream);
            FileStream PokeGirlBaseStream = File.OpenRead(ConfigPath + "PokeGirlBase.xml");
            XmlSerializer PokeGirlBaseserializer = new XmlSerializer(typeof(List<PokeGirlBase>));
            PokeGirlBaseList = (List<PokeGirlBase>)PokeGirlBaseserializer.Deserialize(PokeGirlBaseStream);
            InitDictionary();
        }

        public void InitDictionary()
        {
            foreach (var i in PokeGirlAttributeBaseList)
            {
                PokeGirlAttributeBaseDic.Add(i.ID, i);
            }

            foreach (var i in PokeGirlBaseList)
            {
                PokeGirlBaseDic.Add(i.ID, i);
            }
        }
    }
}