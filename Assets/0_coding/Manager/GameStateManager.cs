using UniRx;

public static class GameStateManager
{
    private static ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.None);
    public static IReadOnlyReactiveProperty<GameState> State => _state;

    public static void ChangeState(GameState state)
    {
        _state.Value = state;
    }
}

public enum GameState
{
    None,
    Start,
    Game,
    Result
}
