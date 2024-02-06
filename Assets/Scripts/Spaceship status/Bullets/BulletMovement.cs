using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float step=6.5f;
    bool isShot;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable(){
        InitialSettings();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        Limits();
    }

    void movement(){
        if (isShot){
            Vector3 unitDir = dir.normalized;
            gameObject.transform.position += unitDir*step*Time.fixedDeltaTime;
        }
    }

    void InitialSettings(){
        isShot=true;
        Transform shipTransform = GameObject.FindGameObjectWithTag("ship").transform;
        gameObject.transform.position = shipTransform.position;
        dir = GameObject.FindGameObjectWithTag("ship").GetComponent<Movement>().Components;
    }

    void Limits(){
        Vector3 currentPos = gameObject.transform.position;
        bool limits = currentPos.y <-5 || currentPos.y > 3.9f || currentPos.x < -8.9f || currentPos.x > 8.9f;
        if(limits){
            Transform ammo = GameObject.FindGameObjectWithTag("ammo").transform;
            gameObject.transform.SetParent(ammo);
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other){

        bool isAsteroid = other.CompareTag("big") || other.CompareTag("medium") || other.CompareTag("small");
        if (isAsteroid){
            Transform ammo = GameObject.FindGameObjectWithTag("ammo").transform;
            gameObject.transform.SetParent(ammo);
            gameObject.SetActive(false);
        }
    }
}
