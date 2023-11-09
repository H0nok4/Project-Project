using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Object = System.Object;

namespace ConfigType {
    public class ResourceLoadManager : MonoSingleton<ResourceLoadManager> {
        public List<T> Load<T>(string path)
        {
            List<T> result = new List<T>();

            Object[] loadedObjects = Resources.LoadAll(path, typeof(T));

            for (int i = 0; i < loadedObjects.Length; i++) {
                result.Add((T)loadedObjects[i]);
            }

            return result;
        }
    }
}
