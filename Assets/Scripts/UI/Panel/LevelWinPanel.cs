public class LevelWinPanel : Panel
{
    void OnEnable()
    {
        HidePanel();
        EventManager.OnLevelFinish.AddListener(ShowPanel);
        EventManager.OnLevelStart.AddListener(HidePanel);
    }

    void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(ShowPanel);
        EventManager.OnLevelStart.RemoveListener(HidePanel);

    }
}