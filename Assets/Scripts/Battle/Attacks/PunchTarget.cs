using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PunchTarget : MonoBehaviour, IPointerClickHandler
{
    public PunchAttack Attack;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Attack.Hit();
    }
}
