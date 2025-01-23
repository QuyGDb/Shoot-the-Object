using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [HideInInspector] public int gameLevel;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameLevel"))
        {
            gameLevel = PlayerPrefs.GetInt("GameLevel");
        }
        else
        {
            gameLevel = 1;
            PlayerPrefs.SetInt("GameLevel", gameLevel);
            PlayerPrefs.Save();
        }
    }


}
