using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EndLevel();
    }

    void EndLevel(){
        bool isThereAsteroids = (GameObject.FindGameObjectWithTag("big")==null)&&(GameObject.FindGameObjectWithTag("medium")==null)&&(GameObject.FindGameObjectWithTag("small")==null);
        AsteroidEnable asteroidActivation = GameObject.FindGameObjectWithTag("asteroid").GetComponent<AsteroidEnable>();
        if (isThereAsteroids){
            asteroidActivation.EnableAsteroidLevel();
            level++;
        }
    }


}
