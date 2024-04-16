using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(StartUIView))] 
public class StartUIPresenter : PresenterBase<StartUIView>
{
    protected override void SetEvent()
    {
        base.SetEvent();
        SetEventShow();
    }

    private void SetEventShow()
    {
        GameStateManager.State
            .TakeUntilDestroy(this)
            .Select(value => value == GameState.Start)
            .Subscribe(async value => 
            {
                if (value)
                {
                    await View.ShowAsync(this.GetCancellationTokenOnDestroy());
                    ChangeInteractive(true);
                }
                else
                {
                    await View.HideAsync(this.GetCancellationTokenOnDestroy());
                    ChangeInteractive(false);
                }
            });
    }
}
