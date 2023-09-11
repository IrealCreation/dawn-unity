using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextBehaviour : MonoBehaviour
{
    private float time = 0f;
    private float duration = 1f;
    private int maxY = 150;
    private bool upside = true; // True if we are going up, false if we are going down

    public RectTransform ThisRect;
    public TextMeshProUGUI Text;
    public RectTransform TextRect;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        float ratio = time / duration;
        float y = ratio * maxY;
        if (!upside)
            y *= -1;
        Vector2 position = new Vector2(0, y);
        TextRect.anchoredPosition = position;

        // Fade out the damage text starting in the last half of the animation
        if (ratio > 0.5f)
        {
            float alpha = 255 - (ratio - 0.5f) * 2 * 255;
            Text.faceColor = new Color(130 / 255f, 0, 0, alpha / 255f);
        }

        if (time > duration)
        {
            Destroy(this);
        }
    }

    public void SetDamage(int damage, bool upside = true)
    {
        Text.text = "- " + damage;
        this.upside = upside;
    }
}
