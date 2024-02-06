using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AsteroidEnable : MonoBehaviour
{
    GameObject [] asteroids;
    // Start is called before the first frame update
    void OnEnable()
    {
        asteroids = GameObject.FindGameObjectsWithTag("big");
        // EnableAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAsteroidLevel(){
        Debug.Log("end level" + asteroids.Length);
        foreach (GameObject asteroid in asteroids)
        {
            asteroid.SetActive(true);
        }
    }
}
