using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using System.IO;

public class Keep_Object : MonoBehaviour
{
//    public bool[] ToggleList;
    public Toggle ToggleButton;
    //public GameObject DisableTemp;
    //public GameObject EnableTemp;
    //public Button ButtonClicked;
    //bool[] myArray = new bool[] { };
    bool[] myArray = new bool[1] { true };


    //public GameObject KeepList;
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


    /*void Update()
     {
         //ClearLog();
         //bool[] myArray = new bool[1] { true };
         //bool togglesound = gameObject.GetComponent<Toggle>().isOn;
         //EnableTemp.SetActive(true);
         //EnableTemp.SetActive(true);
         GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Toggle");
         if (ObjectList.Length > 1)
         {
             Destroy(ObjectList[1].gameObject);
             DisableTemp.SetActive(false);
         }
         if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true && myArray[0] == true)
         {
             myArray[0] = true;
             Debug.Log(myArray[0]);
         }
         else if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true && myArray[0] == false)
         {
             myArray[0] = false;
             Debug.Log(myArray[0]);
         }
         else if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == true)
         {
             myArray[0] = false;
             Debug.Log(myArray[0]);
         }
         else if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == true)
         {
             myArray[0] = false;
             Debug.Log(myArray[0]);
         }
         ToggleButton.GetComponentInChildren<Toggle>().isOn = myArray[0];
         for (int i=0;i< ObjectList.Length;i++)
         {
             Debug.Log(ObjectList[i]);
         }
         Debug.Log(ObjectList.Length);
         DontDestroyOnLoad(this.gameObject);
     }*/

     void Update()
     {
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true)
        {
            myArray[0] = true;
            OutputVariable(myArray[0]);
        }
        if(ToggleButton.GetComponentInChildren<Toggle>().isOn == false)
        {
            myArray[0] = false;
            OutputVariable(myArray[0]);
        }
    }

    public bool OutputVariable(bool Array)
    {
        myArray[0] = Array;
        return myArray[0];
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ClearLog();
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Toggle");
        DontDestroyOnLoad(this.gameObject);
        if (scene.name == "menu_scene" && myArray[0] == true)
        {
            if (ObjectList.Length > 1)
            {
                Destroy(ObjectList[0].gameObject);
                Debug.Log("Current Array Value: " + myArray[0]);
            }
            ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            myArray[0] = true;
        }
        else if (scene.name == "menu_scene" && myArray[0] == false)
        {
            if (ObjectList.Length > 1)
            {
                Destroy(ObjectList[0].gameObject);
                Debug.Log("Current Array Value: " + myArray[0]);
            }
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            myArray[0] = ToggleButton.isOn;
        }
        if (scene.name == "Intro_Scene" && myArray[0] == true)
        {
            if (ObjectList.Length > 1)
            {
                Destroy(ObjectList[0].gameObject);
                Debug.Log("Current Array Value: " + myArray[0]);
            }
            ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            Debug.Log("Success 1");
        }
        else if (scene.name == "Intro_Scene" && myArray[0] == false)
        {
            if (ObjectList.Length > 1)
            {
                Destroy(ObjectList[0].gameObject);
                Debug.Log("Current Array Value: " + myArray[0]);
            }
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            Debug.Log("Success 2");
        }
        //ClearLog();
        //bool togglesound = gameObject.GetComponent<Toggle>().isOn;
        //GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Toggle");
        /*if (ObjectList.Length > 1)
        {
            Destroy(ObjectList[0].gameObject);
        }*/
        /*if (scene.name == "tutorial_scene")
        {
            DisableTemp.SetActive(false);
            //ToggleButton.GetComponentInChildren<Toggle>().isOn = myArray[0];
            //Debug.Log(ObjectList[0].gameObject);
            Debug.Log(ToggleButton.isOn);
        }
        if (scene.name == "Intro_Scene")
        {
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;*/
        //Destroy(ObjectList[0].gameObject);
        /*if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true && myArray[0] == true)
        {
            myArray[0] = true;
            ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            //Debug.Log(myArray[0]);
        }
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true && myArray[0] == false)
        {
            myArray[0] = false;
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            //Debug.Log(myArray[0]);
        }
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == true)
        {
            myArray[0] = false;
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            //Debug.Log(myArray[0]);
        }
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == false)
        {
            myArray[0] = false;
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            //Debug.Log(myArray[0]);
        }*/
        //Debug.Log(myArray[0]);
        //Debug.Log(ObjectList[0].gameObject);
        //Debug.Log(ToggleButton.isOn);
        //}
        /*if (scene.name == "menu_scene")
        {
            //Destroy(ObjectList[0].gameObject);
            //Debug.Log(ObjectList[0].gameObject);
            if (myArray[0] == true)
            {
                myArray[0] = true;
                ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            }
            if (myArray[0] == false)
            {
                myArray[0] = false;
                ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            }
            Debug.Log(ToggleButton.isOn);
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        //DontDestroyOnLoad(this.gameObject);*/
    }


    /*
    void Update()
     {
        //ClearLog();
        //bool[] myArray = new bool[1] { true };
        bool[] myArray;
        //bool togglesound = gameObject.GetComponent<Toggle>().isOn;
        //EnableTemp.SetActive(true);
        //EnableTemp.SetActive(true);
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Toggle");
        if (ObjectList.Length > 1)
        {
            Destroy(ObjectList[0].gameObject);
            //Destroy(this.gameObject);
        }
        if (ToggleButton.GetComponentInChildren<Toggle>().isOn == true && myArray[0] == true)
        {
            ToggleButton.GetComponentInChildren<Toggle>().isOn = true;
            myArray[0] = ToggleButton.isOn;
        }
        else if(ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == true)
        {
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            myArray[0] = ToggleButton.isOn;
        }
        else if (ToggleButton.GetComponentInChildren<Toggle>().isOn == false && myArray[0] == false)
        {
            ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
            myArray[0] = ToggleButton.isOn;
        }
        Debug.Log(myArray[0]);
        DontDestroyOnLoad(this.gameObject);
    }*/

    /*
void Awake()
{
    EnableTemp.SetActive(false);
    ToggleButton.GetComponentInChildren<Toggle>().isOn = false;
    EnableTemp.SetActive(false);
}
*/
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
