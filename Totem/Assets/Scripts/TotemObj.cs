using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TotemObj : MonoBehaviour
{
    public void RotateTotem(string direction) 
    {
        float endValue;
        float duration = 1;

        if (direction == "right")
        {            
            endValue = gameObject.transform.rotation.y - 360.0f;
        }
        else 
        {
            endValue = gameObject.transform.rotation.y + 360.0f;
        }

        Debug.Log("calling rotate");
        Debug.Log("x - " + gameObject.transform.rotation.x);
        Debug.Log("y - " + gameObject.transform.rotation.y);
        Debug.Log("z - " + gameObject.transform.rotation.z);
        Debug.Log("endValue - " + endValue);
        this.gameObject.transform.DORotate(new Vector3(0, endValue, 0), duration, RotateMode.LocalAxisAdd);
    }
}
