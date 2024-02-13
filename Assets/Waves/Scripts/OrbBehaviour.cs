using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class OrbBehaviour : MonoBehaviour
{
    Transform player;
    bool isShoot;
    Vector3 dir;
    float timer =0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OrbMovement();
    }
    void Update(){
        Shoot();
        timer+=Time.deltaTime;
        Timer();
    }



    void OrbMovement(){
        if(!isShoot){
            gameObject.transform.position = player.position + new Vector3 (0,1.2f,0);
        }
        else{
            gameObject.transform.position += dir *15*Time.fixedDeltaTime;
        }
    }

    void Shoot(){
        if (Mouse.current.leftButton.wasPressedThisFrame && !isShoot){
            isShoot = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            mousePos.z = 0;
            dir =  (mousePos - gameObject.transform.position).normalized;

            timer =0;

            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    void Timer(){
        if (timer>4){
            isShoot=false;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("enemy")){
            isShoot=false;
            other.gameObject.GetComponent<EnemyActions>().DecreaseHP();
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
