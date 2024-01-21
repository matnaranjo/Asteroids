using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp 
{
    
    public static void Warping(GameObject astralBody){
        Vector3 prevPos = astralBody.transform.position;

        if (prevPos.y > 4.3){
            Vector3 newPos = new Vector3 (prevPos.x, -5.25f);
            astralBody.transform.position = newPos;
        }
        else if (prevPos.y < -5.3f){
            Vector3 newPos = new Vector3 (prevPos.x, 4.25f);
            astralBody.transform.position = newPos;
        }

        if (prevPos.x > 9.2){
            Vector3 newPos = new Vector3 (-9.15f, prevPos.y);
            astralBody.transform.position = newPos;
        }
        else if(prevPos.x < -9.2){
            Vector3 newPos = new Vector3 (9.15f, prevPos.y);
            astralBody.transform.position = newPos;
        }
    }

}
