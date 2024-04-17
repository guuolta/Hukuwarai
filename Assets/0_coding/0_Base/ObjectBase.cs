using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    private CancellationToken _ct;
    /// <summary>
    /// キャンセレーショントークン
    /// </summary>
    public CancellationToken Ct
    {
        get
        {
            if (_ct == null)
                _ct = this.GetCancellationTokenOnDestroy();

            return _ct;
        }
    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void OnDestroy()
    {

    }


    /// <summary>
    /// イベント削除
    /// </summary>
    protected virtual CompositeDisposable DisposeEvent(CompositeDisposable disposable)
    {
        if(disposable.Count == 0)
        {
            return disposable;
        }

        disposable.Dispose();
        return new CompositeDisposable();
    }
}
