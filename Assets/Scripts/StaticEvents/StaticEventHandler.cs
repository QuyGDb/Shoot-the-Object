
using System;

public static class StaticEventHandler
{
    public static Action OnObjectDestroyed;

    public static void ObjectDestroyed()
    {
        OnObjectDestroyed?.Invoke();
    }
}
