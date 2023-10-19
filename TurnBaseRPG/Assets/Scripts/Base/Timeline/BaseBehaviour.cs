using UnityEngine.Playables;

public abstract class BaseBehaviour : PlayableBehaviour {
    private bool _started;
    private bool _played;
    private object _playerData;
    private Playable _playable = Playable.Null;
    private PlayableAsset _asset;

    public static Playable CreatePlayable<T>(PlayableGraph graph, PlayableAsset data) where T : BaseBehaviour, new() {
        var playable = ScriptPlayable<T>.Create(graph);
        T behaviour = playable.GetBehaviour();
        behaviour._asset = data;
        behaviour._playable = playable;
        return playable;
    }

    #region protected  

    protected T GetData<T>() where T : PlayableAsset => _asset as T;
    protected float Time => (float)_playable.GetTime();
    protected float Duration => (float)_playable.GetDuration();
    protected float Percent => (float)(_playable.GetDuration().Equals(0) ? 0 : _playable.GetTime() / _playable.GetDuration());

    #endregion protected

    #region base
    protected virtual void OnCreate() { }
    protected virtual void OnDestroy() { }
    protected virtual void OnStart(object binding) { }
    protected virtual void OnUpdate(object binding, float deltaTime) { }
    protected virtual void OnStop(object binding) { }
    #endregion base

    #region sealed
    public sealed override void OnBehaviourPlay(Playable playable, FrameData info) {
        if (_played)
            return;
        _started = false;
        _played = true;
    }

    public sealed override void OnBehaviourPause(Playable playable, FrameData info) {
        if (!_played)
            return;
        OnStop(_playerData);
        _played = false;
    }

    public sealed override void OnPlayableCreate(Playable playable) {
        OnCreate();
    }

    public sealed override void OnPlayableDestroy(Playable playable) {
        OnDestroy();
    }

    public sealed override void OnGraphStart(Playable playable) { }

    public sealed override void OnGraphStop(Playable playable) { }

    public sealed override void PrepareData(Playable playable, FrameData info) { }

    public sealed override void PrepareFrame(Playable playable, FrameData info) { }

    public sealed override void ProcessFrame(Playable playable, FrameData info, object playerData) {
        if (!_played)
            return;
        if (!_started) {
            _started = true;
            _playerData = playerData;
            OnStart(_playerData);
        }
        OnUpdate(_playerData, info.deltaTime);
    }
    #endregion sealed
}