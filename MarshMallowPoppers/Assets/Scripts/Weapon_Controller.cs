using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour {

    public int selectedWeapon;
    public GameObject BackPanel1;
    public GameObject BackPanel2;
    public GameObject BackPanel3;

    // Use this for initialization
    void Start()
    {
        selectedWeapon = 0;
        BackPanel1.SetActive(true);
        BackPanel2.SetActive(false);
        BackPanel3.SetActive(false);
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            if(selectedWeapon == 0)
            {
                BackPanel1.SetActive(true);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 1)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(true);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 2)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(true);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon < 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
            if (selectedWeapon == 0)
            {
                BackPanel1.SetActive(true);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 1)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(true);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 2)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
            if (selectedWeapon == 0)
            {
                BackPanel1.SetActive(true);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 1)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(true);
                BackPanel3.SetActive(false);
            }
            else if (selectedWeapon == 2)
            {
                BackPanel1.SetActive(false);
                BackPanel2.SetActive(false);
                BackPanel3.SetActive(true);
            }
        }

        if (selectedWeapon != previousSelectedWeapon)
        {
            SelectWeapon();
        }

        

    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                Weapon weapon_script = weapon.gameObject.GetComponentInChildren<Weapon>();
                weapon_script.setFire(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
