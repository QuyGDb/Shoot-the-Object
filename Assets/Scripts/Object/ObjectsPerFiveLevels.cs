using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsPerFiveLevels", menuName = "Scriptable Objects/ObjectsPerFiveLevels", order = 1)]
public class ObjectsPerFiveLevels : ScriptableObject
{
    public int healthBaseLv;
    public float healthIncreaseRatio;
    public GameObject[] objects = new GameObject[3];
    public float[] healthObjectsFloat = new float[3];
    public int[] healthObjectsInt = new int[3];
    public float[] healthLvArray = new float[5];
    //lv4
    public int numberOfObjectType2Lv4;
    public int numberOfObjectType3Lv4;
    //lv5
    public int numberOfObjectType2Lv5;
    public int numberOfObjectType3Lv5;

    [Header("For recording the next value level")]
    public int healthOfNextLv;

    public void SetHealthForObject()
    {
        healthObjectsFloat[0] = healthLvArray[0] / Settings.obj1Lv1;
        healthObjectsFloat[1] = ((healthLvArray[1] - (Settings.obj1Lv2 * healthObjectsFloat[0])) / Settings.obj2Lv2);
        healthObjectsFloat[2] = healthLvArray[2] - (Settings.obj1Lv3 * healthObjectsFloat[0]) - (Settings.obj2Lv3 * healthObjectsFloat[1]);
        for (int i = 0; i < healthObjectsFloat.Length; i++)
        {
            healthObjectsInt[i] = Mathf.CeilToInt(healthObjectsFloat[i]);
        }

    }
    public void SetHealthForLevel()
    {
        healthLvArray[0] = healthBaseLv;
        healthLvArray[1] = healthIncreaseRatio * healthBaseLv;
        healthLvArray[2] = (Mathf.Pow(healthIncreaseRatio, 2) * healthBaseLv);
        healthLvArray[3] = (Mathf.Pow(healthIncreaseRatio, 3) * healthBaseLv);
        healthLvArray[4] = (Mathf.Pow(healthIncreaseRatio, 4) * healthBaseLv);
    }

    public void CalculateObjectCountForLevel4And5()
    {
        // healthIncreaseRatio * 3 * healthBaseLv = numberOfObjectType2Lv4 * healthObjects[1] + (Settings.numberOfObjectsPerLevel - numberOfObjectType2Lv4) * healthObjects[2];
        // healthIncreaseRatio * 3 * healthBaseLv = numberOfObjectType2Lv4 * healthObjects[1] + Settings.numberOfObjectsPerLevel * healthObjects[2] - numberOfObjectType2Lv4 * healthObjects[2];
        numberOfObjectType2Lv4 = (int)((Mathf.Pow(healthIncreaseRatio, 3) * healthBaseLv - Settings.numberOfObjectsPerLevel * healthObjectsFloat[2]) / (healthObjectsFloat[1] - healthObjectsFloat[2]));
        numberOfObjectType3Lv4 = Settings.numberOfObjectsPerLevel - numberOfObjectType2Lv4;
        numberOfObjectType2Lv5 = (int)((Mathf.Pow(healthIncreaseRatio, 4) * healthBaseLv - Settings.numberOfObjectsPerLevel * healthObjectsFloat[2]) / (healthObjectsFloat[1] - healthObjectsFloat[2]));
        numberOfObjectType3Lv5 = Settings.numberOfObjectsPerLevel - numberOfObjectType2Lv5;
    }
    public void ShowHealthOfLv5()
    {
        healthOfNextLv = (int)(Mathf.Pow(healthIncreaseRatio, 5) * healthBaseLv);
    }
}