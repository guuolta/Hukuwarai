using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

[RequireComponent(typeof(FacePartView))]
[RequireComponent(typeof(FacePartOperator))]
public class FacePart : UIBase
{
    private FacePartOperator _operator;
    private FacePartView _view;
    private System.Action _putAction;

    protected override void Init()
    {
        base.Init();
        
        _operator = GetComponent<FacePartOperator>();
        _view = GetComponent<FacePartView>();
        SetActionPut();
    }

    private void SetActionPut()
    {
        _putAction += async () =>
        {
            await _view.HideAsync(Ct);
            FacePartsCountManager.Instance.AddPutCount();
        };
    }

    protected override void SetEvent()
    {
        base.SetEvent();
        _operator.SetEventDrag(RectTransform, _putAction);
        SetEventShow(Ct);
    }

    private void SetEventShow(CancellationToken ct)
    {
        GameStateManager.State
            .TakeUntilDestroy(this)
            .Where(state => state == GameState.Result)
            .Subscribe(_ =>
            {
                _view.ShowAsync(ct).Forget();
            });
    }
}
