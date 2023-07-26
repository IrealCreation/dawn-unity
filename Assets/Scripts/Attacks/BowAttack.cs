using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Attack launched by a BowSequence, iteracting with the game scene.
/// </summary>
public class BowAttack : MonoBehaviour, IPointerClickHandler
{

    public RectTransform ThisTransform;
    public RectTransform AimTranform;
    public RectTransform TargetTransform;
    public RectTransform DeadzoneTransform;
    public Image AimImage;

    private BowSequence sequence;
    
    public int Size;
    public float TargetRatio = 1 / 2f;
    public float DeadzoneRatio = 1 / 6f;
    public float Duration;
    
    private float time = 0f;
    private bool valid = false;
    
    void Update()
    {
        time += Time.deltaTime;
        float completion = 1 - time / Duration;
        //Debug.Log(completion);
        AimTranform.sizeDelta = new Vector2(Size * completion, Size * completion);
        
        // Check for touches
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                Hit();
            }
        }

        if (!valid && completion < TargetRatio)
        {
            // Target zone
            AimImage.color = Color.green;
            valid = true;
        }

        if (valid && completion < DeadzoneRatio)
        {
            // Dead zone
            valid = false;
            Fail();
        }
    }

    public void Init(BowSequence sequence, int posX, int posY, int size, float duration)
    {
        this.sequence = sequence;
        Size = size;
        Duration = duration;
        
        ThisTransform.anchoredPosition = new Vector2(posX, posY);
        ThisTransform.sizeDelta = new Vector2(Size, Size);
        TargetTransform.sizeDelta = new Vector2(Size * TargetRatio, Size * TargetRatio);
        DeadzoneTransform.sizeDelta = new Vector2(Size * DeadzoneRatio, Size * DeadzoneRatio);
    }

    public void Hit()
    {
        if(valid)
            Success();
        else 
            Fail();
    }

    public void Success()
    {
        sequence.AttackEnd(true);
        Object.Destroy(this.gameObject);
    }

    public void Fail()
    {
        sequence.AttackEnd(false);
        Object.Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hit();
    }
}
