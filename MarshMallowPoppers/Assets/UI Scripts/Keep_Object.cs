using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keep_Object : MonoBehaviour
{
    public Toggle[] ToggleList;
    public Toggle ToggleButton;
    public GameObject EnableTemp;
    /*void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(objs[0].gameObject);
            //Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/
    void Start()
     {
         //bool togglesound = gameObject.GetComponent<Toggle>().isOn;
         EnableTemp.SetActive(true);
         ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
         EnableTemp.SetActive(false);
     }

        /*
    void Awake()
    {
        EnableTemp.SetActive(false);
        ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
        EnableTemp.SetActive(false);
    }
    */
}
