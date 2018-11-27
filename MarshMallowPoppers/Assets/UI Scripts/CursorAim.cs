using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAim : MonoBehaviour
{
    void Update()
    {
        Aim();
    }

    void Aim()
    {
        Vector3 MouseAim = Input.mousePosition;
        MouseAim = Camera.main.ScreenToWorldPoint(MouseAim);
        Quaternion rot = Quaternion.LookRotation(transform.position - MouseAim, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
