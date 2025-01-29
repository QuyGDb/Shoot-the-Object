using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [HideInInspector] public int gameLevel;

    private void Awake()
    {
        gameLevel = SaveLoadManager.LoadDataFromPlayerPrefs<int>("GameLevel");
        if (gameLevel == 0)
        {
            gameLevel = 1;
            SaveLoadManager.SaveDataToPlayerPrefs("GameLevel", gameLevel);
        }
    }
    private void Start()
    {

    }
}
