using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;
using UniRx;

public class AbstractScriptableManager<T> : AbstractScriptableManagerBase where T : AbstractScriptableManager<T>
{
    protected CompositeDisposable _compositeDisposable = null;
    public static T Instance;
    public override void Initialize()
    {
        base.Initialize();
        Instance = this as T;
        _compositeDisposable = new CompositeDisposable();
    }
    public override void Destroy()
    {
        base.Destroy();
        _compositeDisposable.Dispose();
    }
}
