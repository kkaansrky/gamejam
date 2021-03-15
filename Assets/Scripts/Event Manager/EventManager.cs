using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    #endregion

}