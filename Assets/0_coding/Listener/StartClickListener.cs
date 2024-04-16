using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class StartClickListener : MonoBehaviour
{
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        SetEventStartClickListen();
    }

    private void SetEventStartClickListen()
    {
        GameStateManager.State
            .TakeUntilDestroy(this)
            .Where(state => state == GameState.Start)
            .Subscribe(_ =>
            {
                SetEventClickListen();
            });
    }

    private void SetEventClickListen()
    {
        _disposable.Clear();

        Observable.EveryUpdate()
            .TakeUntilDestroy(this)
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                GameStateManager.ChangeState(GameState.Game);
                _disposable.Dispose();
            }).AddTo(_disposable);
    }
}
