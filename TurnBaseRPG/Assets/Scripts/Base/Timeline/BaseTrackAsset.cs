using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimelineExtension
{
    public class BaseTrackAsset : TrackAsset {
        protected sealed override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip) {
            return base.CreatePlayable(graph, gameObject, clip);
        }

        public sealed override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
            return base.CreateTrackMixer(graph, go, inputCount);
        }
    }

    public class BaseTrackAsset<T> : TrackAsset where T : BaseBehaviour, new() {
        protected sealed override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip) {
            return base.CreatePlayable(graph, gameObject, clip);
        }

        public sealed override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) {
            var mixer = BaseBehaviour.CreatePlayable<T>(graph, this);
            mixer.SetInputCount(inputCount);
            return mixer;
        }
    }
}
