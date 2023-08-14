using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBarBehaviour : MonoBehaviour
{
    private RectTransform rectTransform;
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
        else if(rectTransform.rect.width > 0)
        {
            float width = rectTransform.rect.width - Time.deltaTime * 200;
            rectTransform.sizeDelta = new Vector2(width, 0);
        }
    }

    public void SetWidth(float width)
    {
        rectTransform.sizeDelta = new Vector2(width, 0);
        cooldown = 1f;
    }
}
