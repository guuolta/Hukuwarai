using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameSetter : ObjectBase
{
    protected override void Awake()
    {
        base.Awake();
        GameStateManager.ChangeState(GameState.Start);

        GameStateManager.State.Subscribe(state =>
        {
            Debug.Log(state);
        }).AddTo(this);
    }
}
