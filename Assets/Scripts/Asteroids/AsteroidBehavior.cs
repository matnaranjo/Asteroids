using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    Rigidbody2D asteroid;
    [SerializeField]
    int angleref1 = 0;
    [SerializeField]
    int angleref2 = 0;
    [SerializeField]
    float force = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        asteroid = gameObject.GetComponent<Rigidbody2D>();
        InitialPush();
    }


    void InitialPush(){

        float angle = Random.Range(angleref1, angleref2)*Mathf.Deg2Rad;
        Vector3 dir = new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle), 0);

        asteroid.AddForce(dir*force, ForceMode2D.Impulse);

    }
}
