using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBarBehaviour : MonoBehaviour
{
    public RectTransform RectTransform;
    private float cooldown = 0f;

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
        else if(RectTransform.rect.width > 0)
        {
            float width = RectTransform.rect.width - Time.deltaTime * 200;
            RectTransform.sizeDelta = new Vector2(width, 0);
        }
    }

    public void SetWidth(float width)
    {
        RectTransform.sizeDelta = new Vector2(width, 0);
        cooldown = 1f;
    }
}
