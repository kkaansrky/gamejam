using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevelButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        
        onClick.AddListener(NextLevelLoad);
    }
    protected override void OnDisable()
    {
        base.OnDisable();

        onClick.RemoveListener(NextLevelLoad);
    }

    void NextLevelLoad()
    {
        LevelManager.Instance.HandleCreateNextLevel();
        EventManager.OnLevelStart.Invoke();
    }

}