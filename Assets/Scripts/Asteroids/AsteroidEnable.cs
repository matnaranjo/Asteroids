using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnableAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableAsteroid(){
        Transform[] asteroids = GetComponentsInChildren<Transform>();
        foreach (Transform asteroid in asteroids)
        {
            asteroid.gameObject.SetActive(true);
        }
    }
}
