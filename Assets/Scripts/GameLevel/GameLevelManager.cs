using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [HideInInspector] public int gameLevel;
    public List<ObjectsPerFiveLevels> objectsPerFiveLevels;
    public ObjectsPerFiveLevels currentObjectsPerFiveLevels;
    public int lvInObjectsPerFiveLevels;
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
        StartLevel();
    }

    private void GetCurrentObjectsForLevel()
    {
        int index = (gameLevel - 1) / 5;
        currentObjectsPerFiveLevels = objectsPerFiveLevels[index];
        lvInObjectsPerFiveLevels = gameLevel % 5;
        if (lvInObjectsPerFiveLevels == 0)
        {
            lvInObjectsPerFiveLevels = 5;
        }
    }

    private void StartLevel()
    {
        GetCurrentObjectsForLevel();
        CreateObject();

    }
    private void CreateObject()
    {
        switch (lvInObjectsPerFiveLevels)
        {
            case 1:
                Lv1();
                break;
            case 2:
                Lv2();
                break;
            case 3:
                Lv3();
                break;
            case 4:
                Lv4();
                break;
            case 5:
                Lv5();
                break;
        }
    }

    private void Lv1()
    {
        List<GameObject> objectsLv1Type = new List<GameObject>();
        for (int i = 0; i < Settings.obj1Lv1; i++)
        {
            GameObject objLv1 = Instantiate(currentObjectsPerFiveLevels.objects[0], transform);
            objLv1.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[0];
            Debug.Log(objLv1 + "test");
            SetObjectTypeAndPosition(objLv1);
            objLv1.SetActive(false);
            objectsLv1Type.Add(objLv1);
        }
    }

    private void Lv2()
    {
        List<GameObject> objectsLv2Type1 = new List<GameObject>();
        List<GameObject> objectsLv2Type2 = new List<GameObject>();
        for (int i = 0; i < Settings.obj1Lv2; i++)
        {
            GameObject objLv2 = Instantiate(currentObjectsPerFiveLevels.objects[0], transform);
            objLv2.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[0];
            SetObjectTypeAndPosition(objLv2);
            gameObject.SetActive(false);
            objectsLv2Type1.Add(objLv2);
        }
        for (int i = 0; i < Settings.obj2Lv2; i++)
        {
            GameObject objLv2 = Instantiate(currentObjectsPerFiveLevels.objects[1], transform);
            objLv2.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[1];
            SetObjectTypeAndPosition(objLv2);
            gameObject.SetActive(false);
            objectsLv2Type2.Add(objLv2);
        }
    }

    private void Lv3()
    {
        List<GameObject> objectsLv3Type1 = new List<GameObject>();
        List<GameObject> objectsLv3Type2 = new List<GameObject>();
        List<GameObject> objectsLv3Type3 = new List<GameObject>();
        for (int i = 0; i < Settings.obj1Lv3; i++)
        {
            GameObject objLv3 = Instantiate(currentObjectsPerFiveLevels.objects[0], transform);
            objLv3.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[0];
            SetObjectTypeAndPosition(objLv3);
            gameObject.SetActive(false);
            objectsLv3Type1.Add(objLv3);
        }
        for (int i = 0; i < Settings.obj2Lv3; i++)
        {
            GameObject objLv3 = Instantiate(currentObjectsPerFiveLevels.objects[1], transform);
            objLv3.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[1];
            SetObjectTypeAndPosition(objLv3);
            gameObject.SetActive(false);
            objectsLv3Type2.Add(objLv3);
        }
        for (int i = 0; i < Settings.obj3Lv3; i++)
        {
            GameObject objLv3 = Instantiate(currentObjectsPerFiveLevels.objects[2], transform);
            objLv3.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[2];
            SetObjectTypeAndPosition(objLv3);
            gameObject.SetActive(false);
            objectsLv3Type3.Add(objLv3);
        }
    }

    private void Lv4()
    {
        List<GameObject> objectsLv4Type2 = new List<GameObject>();
        List<GameObject> objectsLv4Type3 = new List<GameObject>();

        for (int i = 0; i < currentObjectsPerFiveLevels.numberOfObjectType2Lv4; i++)
        {
            GameObject objLv4 = Instantiate(currentObjectsPerFiveLevels.objects[1], transform);
            objLv4.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[1];
            SetObjectTypeAndPosition(objLv4);
            gameObject.SetActive(false);
            objectsLv4Type2.Add(objLv4);
        }
        for (int i = 0; i < currentObjectsPerFiveLevels.numberOfObjectType3Lv4; i++)
        {
            GameObject objLv4 = Instantiate(currentObjectsPerFiveLevels.objects[2], transform);
            objLv4.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[2];
            SetObjectTypeAndPosition(objLv4);
            gameObject.SetActive(false);
            objectsLv4Type3.Add(objLv4);
        }
    }

    private void Lv5()
    {
        List<GameObject> objectsLv5Type2 = new List<GameObject>();
        List<GameObject> objectsLv5Type3 = new List<GameObject>();
        for (int i = 0; i < currentObjectsPerFiveLevels.numberOfObjectType2Lv5; i++)
        {
            GameObject objLv5 = Instantiate(currentObjectsPerFiveLevels.objects[1], transform);
            objLv5.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[1];
            SetObjectTypeAndPosition(objLv5);
            gameObject.SetActive(false);
            objectsLv5Type2.Add(objLv5);
        }
        for (int i = 0; i < currentObjectsPerFiveLevels.numberOfObjectType3Lv5; i++)
        {
            GameObject objLv5 = Instantiate(currentObjectsPerFiveLevels.objects[2], transform);
            objLv5.GetComponent<ObjectHealth>().health = currentObjectsPerFiveLevels.healthObjectsInt[2];
            SetObjectTypeAndPosition(objLv5);
            gameObject.SetActive(false);
            objectsLv5Type3.Add(objLv5);
        }
    }

    public void SetObjectTypeAndPosition(GameObject gameObject)
    {
        Object obj = gameObject.GetComponent<Object>();
        Debug.Log(obj);
        obj.objectMovementType = HelperUtilities.GetRandomEnumValue<ObjectMovementType>();
        gameObject.transform.position = ObjectPositionGenerator.Instance.GetSpawnObjectPosition(obj.objectMovementType);
    }
}
