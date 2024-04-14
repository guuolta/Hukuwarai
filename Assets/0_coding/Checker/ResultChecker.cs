using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultChecker : SingletonObjectBase<ResultChecker>
{
    protected override void SetEvent()
    {
        base.SetEvent();
        SetEventmoveResult();
    }

    private void SetEventmoveResult()
    {
        FacePartsCountManager.Instance.IsPutAll
            .TakeUntilDestroy(this)
            .Where(isPutAll => isPutAll)
            .Subscribe(_ =>
            {
                GameStateManager.ChangeState(GameState.Result);
            });
    }
}
