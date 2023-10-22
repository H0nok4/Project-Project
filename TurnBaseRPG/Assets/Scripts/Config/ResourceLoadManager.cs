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
            // 使用Resources.LoadAll方法加载指定文件夹下的所有Playable文件
            Object[] loadedObjects = Resources.LoadAll(path, typeof(TimelineAsset));

            // 将加载的PlayableAsset转换为PlayableAsset数组
            for (int i = 0; i < loadedObjects.Length; i++) {
                result.Add((T)loadedObjects[i]);
            }

            return result;
        }
    }
}
