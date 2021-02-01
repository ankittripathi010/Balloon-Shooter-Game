using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public shooter shooter;
    public void OnPointerDown(PointerEventData eventdata)
    {
        InvokeRepeating("FireMe", 0, 0.1f);
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        CancelInvoke("FireMe");
    }


    void FireMe()
    {
        shooter.BulletShooter();
    }
}