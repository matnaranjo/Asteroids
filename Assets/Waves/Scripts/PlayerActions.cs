using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    float speed = 1;

    Animator playerAnimator;
    Control playerInputs;

    void Awake(){
        playerInputs = new Control();
        playerAnimator = GetComponent<Animator>();
    }
    void OnEnable(){
        playerInputs.Enable();
    }

    void OnDisable(){
        playerInputs.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Gets the player input and moves the character based on that direction
    /// </summary>
    void Movement(){
        Vector3 dir = playerInputs.Movement.Direction.ReadValue<Vector2>();

        Animation(dir);

        Vector3 step = dir * speed* Time.fixedDeltaTime*2;

        Vector3 check = gameObject.transform.position + step;

        if (check.x<-20|| check.x > 20){
            step = new Vector3(0, step.y);
        }
        if (check.y<-17 || check.y>23){
            step = new Vector3(step.x, 0);
        }
        gameObject.transform.position += step;
    }

    /// <summary>
    /// Takes the <paramref name="dir"/> based on the user input and if the input makes the character walk, the animation changes to walk
    /// </summary>
    /// <param name="dir"></param>
    void Animation(Vector3 dir){
        bool isWalking = playerAnimator.GetBool("isWalking");
        if ((dir.x != 0 || dir.y != 0) && !isWalking ){
            playerAnimator.SetBool("isWalking", true);
        }
        else if (dir.x == 0 && dir.y == 0&& isWalking){
            playerAnimator.SetBool("isWalking", false);
        }
    }

    // IEnumerator Timer(){
    //     yield return new WaitForSeconds()
    // }

}
