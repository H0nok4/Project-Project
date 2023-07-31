using System.Collections.Generic;

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
    }
}