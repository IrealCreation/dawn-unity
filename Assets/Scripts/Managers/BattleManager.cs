using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Main;

    public GameObject BowAttackPrefab;
    public GameObject PunchAttackPrefab;
    public GameObject BattleZone;

    public float ScreenWidth;
    public float ScreenHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        Main = this;
        
        ScreenWidth = BattleZone.GetComponent<RectTransform>().rect.width;
        ScreenHeight = BattleZone.GetComponent<RectTransform>().rect.height;
        
        BowAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BowAttack()
    {
        // new BowSequence(BowAttackPrefab, 300, 5, 3, 0.8f, 0.8f);
        new PunchSequence(PunchAttackPrefab, 300, 10, 1, 20);
    }
}
