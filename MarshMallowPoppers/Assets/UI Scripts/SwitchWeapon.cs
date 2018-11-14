using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public GameObject myscript;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key was pressed.");
            myscript.SetActive(false);
        }
        else
        {
            myscript.SetActive(true);
        }
    }
}
