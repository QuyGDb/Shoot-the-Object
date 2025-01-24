

[System.Serializable]
public class GunAttributes
{
    public float damage;
    public float speed;
    public float income;
    public float money;
    public float priceToUpgradeDamage;
    public float priceToUpgradeSpeed;
    public float priceToUpgradeIncome;
    public int damageLevel;
    public int speedLevel;
    public int incomeLevel;
    public GunAttributes(float damage, float speed, float income, float money,
                    float priceToUpgradeDamage, float priceToUpgradeSpeed, float priceToUpgradeIncome, int damageLevel, int speedLevel, int incomeLevel)
    {
        this.damage = damage;
        this.speed = speed;
        this.income = income;
        this.money = money;
        this.priceToUpgradeDamage = priceToUpgradeDamage;
        this.priceToUpgradeSpeed = priceToUpgradeSpeed;
        this.priceToUpgradeIncome = priceToUpgradeIncome;
        this.damageLevel = damageLevel;
        this.speedLevel = speedLevel;
        this.incomeLevel = incomeLevel;
        this.damage = damage;
        this.speed = speed;
        this.income = income;
    }
}
