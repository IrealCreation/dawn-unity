
using UnityEngine;

/// <summary>
/// Sequence launched when the player selects the battle action with the bow. Contains one or multiple BowAttacks.
/// </summary>
public class BowSequence
{
    public GameObject BowAttackPrefab;

    private int size;
    private float duration;
    private int attackNumber;
    private int attackCount = 0;
    private float sizeModifier;
    private float durationModifier;

    private int successCount = 0;

    public BowSequence(GameObject bowAttackPrefab, int size, float duration, int attackNumber, float sizeModifier = 1f, float durationModifier = 1f)
    {
        BowAttackPrefab = bowAttackPrefab;
        this.size = size;
        this.duration = duration;
        this.attackNumber = attackNumber;
        this.sizeModifier = sizeModifier;
        this.durationModifier = durationModifier;
        
        LaunchAttack();
    }

    public void LaunchAttack()
    {
        attackCount++;

        int computedSize = (int)Mathf.Round(size * Mathf.Pow(sizeModifier, attackCount));
        float computedDuration = duration * Mathf.Pow(sizeModifier, attackCount);

        int posX = (int)Random.Range(0, Mathf.Floor(BattleManager.Main.ScreenWidth - size));
        int posY = 0 - (int)Random.Range(0, Mathf.Floor(BattleManager.Main.ScreenHeight - size));
        
        GameObject bowAttack = GameObject.Instantiate(BowAttackPrefab, BattleManager.Main.BattleZone.transform);
        bowAttack.GetComponent<BowAttack>().Init(this, posX, posY, computedSize, computedDuration);
        
    }

    public void AttackEnd(bool success)
    {
        if (success)
            successCount++;
        
        if(attackCount == attackNumber)
            SequenceEnd();
        else
            LaunchAttack();
    }

    public void SequenceEnd()
    {
        
    }
}