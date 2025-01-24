using UnityEngine;

[CreateAssetMenu(fileName = "GunAtributesSO", menuName = "Scriptable Objects/GunAtributesSO", order = 1)]
public class GunAtributesSO : ScriptableObject
{
    public GunAttributes gunAttributes;
    // C� x�c ??nh ???c max speed c?a gun tr??c n�n d�ng curve
    public AnimationCurve speedCurve;

    private void OnEnable()
    {
        var loadedData = SaveLoadManager.LoadDataFromPlayerPrefs("GunAttributes");
        if (loadedData != null)
        {
            gunAttributes = (GunAttributes)loadedData;
        }
    }
}
