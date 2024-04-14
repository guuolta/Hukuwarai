using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class FacePartOperator : ObjectBase
{
    private ObservableEventTrigger _eventTrigger;
    private CompositeDisposable _disposable = new CompositeDisposable();

    protected override void Init()
    {
        base.Init();
        SetEventTrigger();
    }

    private void SetEventTrigger()
    {
        _eventTrigger = GetComponent<ObservableEventTrigger>();
        if (_eventTrigger != null)
            return;

        _eventTrigger = gameObject.AddComponent<ObservableEventTrigger>();
    }

    public void SetEventDrag(RectTransform rectTransform, Action hideAnimation)
    {
        _eventTrigger.OnDragAsObservable()
            .TakeUntilDestroy(this)
            .Select(_ => Input.mousePosition)
            .Subscribe(pos =>
            {
                rectTransform.position = pos;
            })
            .AddTo(_disposable);

        _eventTrigger.OnEndDragAsObservable()
            .TakeUntilDestroy(this)
            .Where(_ => HukuwaraiPosChecker.Instance.CheckPos(rectTransform))
            .Subscribe(_ =>
            {
                hideAnimation.Invoke();
                DisposeEvent(_disposable);
            })
            .AddTo(_disposable);
    }
}
