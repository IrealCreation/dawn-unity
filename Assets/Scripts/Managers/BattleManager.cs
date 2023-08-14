using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Main;

    public GameObject BowAttackPrefab;
    public GameObject PunchAttackPrefab;

    public GameObject BattleZone;

    public RectTransform HeroHealthBar;
    public DamageBarBehaviour HeroDamageBar;
    public TextMeshProUGUI HeroHealthText;
    public RectTransform EnemyHealthBar;
    public DamageBarBehaviour EnemyDamageBar;
    public TextMeshProUGUI EnemyHealthText;

    public Character Hero;
    public Character Enemy;

    public float ScreenWidth;
    public float ScreenHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        Main = this;

        Hero = new Character(100);
        Enemy = new Character(90);

        ScreenWidth = BattleZone.GetComponent<RectTransform>().rect.width;
        ScreenHeight = BattleZone.GetComponent<RectTransform>().rect.height;

        UpdateHeroBar(0);
        UpdateEnemyBar(0);

        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        new BowSequence(BowAttackPrefab, 300, 5, 3, 0.8f, 0.8f);
        // new PunchSequence(PunchAttackPrefab, 300, 10, 1, 20);
    }

    public void DamageToHero(int damage)
    {
        bool isAlive = Hero.changeHealth(0 - damage);

        UpdateHeroBar(damage);

        // TODO: damage text
    }

    public void DamageToEnemy(int damage)
    {
        bool isAlive = Enemy.changeHealth(0 - damage);

        UpdateEnemyBar(damage);

        // TODO: damage text
    }

    public void UpdateHeroBar(int damage)
    {
        float healthWidth = (float)Hero.GetHealth() / Hero.GetMaxHealth() * ScreenWidth;
        float damageWidth = (float)damage / Hero.GetMaxHealth() * ScreenWidth;
        HeroHealthBar.sizeDelta = new Vector2(healthWidth, 100);
        HeroDamageBar.SetWidth(damageWidth);

        HeroHealthText.text = string.Format("{0} / {1}", Hero.GetHealth(), Hero.GetMaxHealth());

    }

    public void UpdateEnemyBar(int damage)
    {
        float healthWidth = (float)Enemy.GetHealth() / Enemy.GetMaxHealth() * ScreenWidth;
        float damageWidth = (float)damage / Enemy.GetMaxHealth() * ScreenWidth;
        EnemyHealthBar.sizeDelta = new Vector2(healthWidth, 100);
        EnemyDamageBar.SetWidth(damageWidth);

        EnemyHealthText.text = string.Format("{0} / {1}", Enemy.GetHealth(), Enemy.GetMaxHealth());

    }
}
