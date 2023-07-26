using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sequence launched when the player selects the battle action with the punch weapon. Contains one or multiple PunchAttacks.
/// </summary>
public class PunchSequence
{
    public GameObject PunchAttackPrefab;

    private int size;
    private float duration;
    private float speed;
    private int hitObjective;
    
    public PunchSequence(GameObject punchAttackPrefab, int size, float duration, float speed, int hitObjective) 
    {
        Debug.Log("Punch Sequence");
        PunchAttackPrefab = punchAttackPrefab;
        this.size = size;
        this.duration = duration;
        this.speed = speed;
        this.hitObjective = hitObjective;

        LaunchAttack();
    }

    public void LaunchAttack()
    {
        int posX = (int)Random.Range(0, Mathf.Floor(BattleManager.Main.ScreenWidth - size));
        int posY = 0 - (int)Random.Range(0, Mathf.Floor(BattleManager.Main.ScreenHeight - size));
        
        GameObject punchAttack = GameObject.Instantiate(PunchAttackPrefab, BattleManager.Main.BattleZone.transform);
        punchAttack.GetComponent<PunchAttack>().Init(this, posX, posY, size, duration, speed, hitObjective);
        
    }

    public void EndAttack(int hitDone) {
        
    }
}
