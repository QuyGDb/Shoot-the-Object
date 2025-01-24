using UnityEngine;

[CreateAssetMenu(fileName = "GunAtributesSO", menuName = "Scriptable Objects/GunAtributesSO", order = 1)]
public class GunAtributesSO : ScriptableObject
{
    public float baseDamage;
    public float baseSpeed;
    public float baseIncome;
    public float baseMoney;
    public float basePriceToUpgradeDamage;
    public float basePriceToUpgradeSpeed;
    public float basePriceToUpgradeIncome;
    public int baseDamageLevel;
    public int baseSpeedLevel;
    public int baseIncomeLevel;
    public GunAttributes gunAtributes;
    // Có xác định được max speed của gun trước nên dùng curve
    public AnimationCurve speedCurve;

    private void OnEnable()
    {
        LoadGunAtributes();
    }

    void LoadGunAtributes()
    {
        var gunAtr = SaveLoadManager.LoadDataFromPlayerPrefs<GunAttributes>("GunAttributes");
        if (gunAtr != null)
        {
            gunAtributes = gunAtr;
        }
        else
        {
            gunAtributes = new GunAttributes(baseDamage, baseSpeed, baseIncome, baseMoney, basePriceToUpgradeDamage,
                basePriceToUpgradeSpeed, basePriceToUpgradeIncome, baseDamageLevel, baseSpeedLevel, baseIncomeLevel);
            SaveGunAtributes();
        }
    }

    public void SaveGunAtributes()
    {
        SaveLoadManager.SaveDataToPlayerPrefs("GunAttributes", gunAtributes);
    }

    public void UpgradeDamage(int level)
    {
        if (gunAtributes.money < gunAtributes.priceToUpgradeDamage) return;
        UpgradeDamageByLevel(level);
        UpgradePriceForDamage(level);
        gunAtributes.damageLevel = level;
        gunAtributes.damageLevel++;
        gunAtributes.money -= gunAtributes.priceToUpgradeDamage;
        SaveGunAtributes();
    }
    private void UpgradeDamageByLevel(int level)
    {
        gunAtributes.damage = gunAtributes.damage + level;
    }
    private void UpgradePriceForDamage(int level)
    {
        gunAtributes.priceToUpgradeDamage = gunAtributes.priceToUpgradeSpeed * 2;
    }

    public void UpgradeSpeed(int level)
    {
        if (gunAtributes.money < gunAtributes.priceToUpgradeSpeed) return;
        UpgradeSpeedByLevel(level);
        UpgradePriceForSpeed(level);
        gunAtributes.speedLevel = level;
        gunAtributes.speedLevel++;
        gunAtributes.money -= gunAtributes.priceToUpgradeSpeed;
        SaveGunAtributes();
    }
    private void UpgradeSpeedByLevel(int level)
    {
        if (level == 0) return;

        if (level > speedCurve.keys.Length)
            level = speedCurve.keys.Length;
        gunAtributes.speed = speedCurve.Evaluate(level);
    }


    private void UpgradePriceForSpeed(int level)
    {
        if (level == 50) return;
        gunAtributes.priceToUpgradeSpeed = gunAtributes.priceToUpgradeSpeed * 2;
    }

    public void UpgradeIncome(int level)
    {
        if (gunAtributes.money < gunAtributes.priceToUpgradeIncome) return;
        UpgradeIncomeByLevel(level);
        UpgradePriceForIncome(level);
        gunAtributes.incomeLevel = level;
        gunAtributes.incomeLevel++;
        gunAtributes.money -= gunAtributes.priceToUpgradeIncome;
        SaveGunAtributes();
    }
    private void UpgradePriceForIncome(int level)
    {
        gunAtributes.priceToUpgradeIncome = gunAtributes.priceToUpgradeSpeed * 2;
    }
    private void UpgradeIncomeByLevel(int level)
    {
        gunAtributes.income = gunAtributes.income + 2 * level - 1;
    }
}
