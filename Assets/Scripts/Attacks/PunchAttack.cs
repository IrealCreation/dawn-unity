using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PunchAttack : MonoBehaviour
{
    public RectTransform TargetTransform;
    public RectTransform TimeBarTransform;
    public TMP_Text HitCount;

    private PunchSequence sequence;
    
    public int Size;
    public float Duration;
    public float Speed;
    
    private float time = 0f;
    private int hitDone = 0;
    private int hitObjective;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float completion = 1 - time / Duration;

        int timeBarWidth = Mathf.RoundToInt(completion * BattleManager.Main.ScreenWidth);
        TimeBarTransform.sizeDelta = new Vector2 (timeBarWidth, TimeBarTransform.sizeDelta.y);

        if(time >= Duration) {
            End();
        }
    }

    public void Init(PunchSequence sequence, int posX, int posY, int size, float duration, float speed, int hitObjective)
    {
        this.sequence = sequence;
        Size = size;
        Duration = duration;
        Speed = speed;
        this.hitObjective = hitObjective;
        
        TargetTransform.anchoredPosition = new Vector2(posX, posY);
        TargetTransform.sizeDelta = new Vector2(Size, Size);

        UpdateHitCount();
    }

    private void UpdateHitCount() {
        HitCount.text = (hitObjective - hitDone).ToString();
    }

    public void Hit() {
        hitDone ++;
        UpdateHitCount();
        if(hitDone == hitObjective) {
            End();
        }
    }

    public void End() {
        Object.Destroy(this.gameObject);
        sequence.EndAttack(hitDone);
    }
}
