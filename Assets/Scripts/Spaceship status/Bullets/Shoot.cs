using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    Inputs playerInputs;

    GameObject ammo;
    GameObject shot;


    #region Enable and Disable
    void OnEnable(){
        playerInputs.Enable();
    }

    void OnDisable(){
        playerInputs.Disable();
    }
    #endregion

    void Awake(){
        playerInputs = new Inputs();
    }
    // Start is called before the first frame update
    void Start()
    {
        ammo = GameObject.FindGameObjectWithTag("ammo");
        shot = GameObject.FindGameObjectWithTag("shot");
    }

    // Update is called once per frame
    void Update()
    {
        EnableBullet();
        
    }

    void EnableBullet(){
        Transform bullet;
        if(Mouse.current.leftButton.wasPressedThisFrame){
            bullet = ammo.transform.GetChild(0);
            bullet.gameObject.SetActive(true);
            bullet.SetParent(shot.transform);
        }
    }
}
