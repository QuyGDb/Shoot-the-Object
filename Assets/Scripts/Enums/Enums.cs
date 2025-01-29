public enum GameState
{
    MainMenu,
    Game,
    GameOver
}

public enum BoundaryType
{
    Top,
    Bottom,
    Left,
    Right
}
public enum ObjectMovementType
{
    HorizontalLeftToRight,
    HorizontalRightToLeft,
    DiagonalLeftTopToRightBottom,
    DiagonalRightBottomToLeftTop,
    DiagonalLeftBottomToRightTop,
    DiagonalRightTopToLeftBottom,
}

public enum ObjectType
{
    Normal,
    RewardMoney,
    InstantLose,
    SlowDown,
    AddTime
}