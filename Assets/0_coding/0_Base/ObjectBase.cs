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

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        SetEvent();
    }

    private void OnDestroy()
    {
        Destroy();
    }

    /// <summary>
    /// 変数の初期化など
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// イベントの発行
    /// </summary>
    protected virtual void SetEvent()
    {

    }

    /// <summary>
    /// インスタンス破壊時にする処理
    /// </summary>
    protected virtual void Destroy()
    {

    }

    /// <summary>
    /// イベント削除
    /// </summary>
    protected virtual CompositeDisposable DisposeEvent(CompositeDisposable disposable)
    {
        disposable.Dispose();
        return new CompositeDisposable();
    }
}
