using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    [SerializeField]
    Sprite[] asteroidSprites;
    [SerializeField]
    int angleref1 = 0;
    [SerializeField]
    int angleref2 = 0;
    [SerializeField]
    float force = 0;
    [SerializeField]
    Vector3 initialPos;
    bool isWarpable;
    Rigidbody2D asteroid;

    #region storages
    Transform bigStorage;
    Transform mediumStorage;
    Transform smallStorage;
    Transform activeStorage;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        activeStorage = GameObject.FindGameObjectWithTag("asteroid").transform;
        bigStorage = GameObject.FindGameObjectWithTag("asteroidbig").transform;
        mediumStorage = GameObject.FindGameObjectWithTag("asteroidmedium").transform;
        smallStorage = GameObject.FindGameObjectWithTag("asteroidsmall").transform;
        
    }


    // Initial Push of the asteroid
    void OnEnable()
    {
        asteroid = gameObject.GetComponent<Rigidbody2D>();
        SpriteSelection();
        InitialPush();
    }
    
    //Keps track of position of the asteroid and warps it if necessary 
    void FixedUpdate(){
        if(isWarpable){
            Warp.Warping(gameObject);
        }
    }



    void InitialPush(){
        if (gameObject.CompareTag("big")){
            gameObject.transform.position = initialPos;
            float angle = Random.Range(angleref1, angleref2)*Mathf.Deg2Rad;
            Vector3 dir = new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle), 0);
            asteroid.AddForce(dir*force, ForceMode2D.Impulse);
        }
        else {
            Vector3 dir = Random.insideUnitCircle.normalized;
            asteroid.AddForce(dir*force, ForceMode2D.Impulse);
        }
    }

    void SpriteSelection(){
        int index;
        if(gameObject.CompareTag("big")){
            index = Random.Range(0,2);
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSprites[index];
        }
        else if(gameObject.CompareTag("medium")){
            index = Random.Range(2,4);
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSprites[index];
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().sprite = asteroidSprites[4];
        }
    }

    void ActivateAsteroids(){
        if (gameObject.CompareTag("big")){
            Transform medium1 = mediumStorage.GetChild(0);
            Transform medium2 = mediumStorage.GetChild(1);
            medium1.position = gameObject.transform.position;
            medium1.gameObject.SetActive(true);
            medium2.position = gameObject.transform.position;
            medium1.SetParent(activeStorage);
            medium2.gameObject.SetActive(true);
            medium2.SetParent(activeStorage);


        }
        else if(gameObject.CompareTag("medium")){
            Transform small1 = smallStorage.GetChild(0);
            Transform small2 = smallStorage.GetChild(1);
            small1.position = gameObject.transform.position;
            small1.gameObject.SetActive(true);
            small1.SetParent(activeStorage);
            small2.position = gameObject.transform.position;
            small2.gameObject.SetActive(true);
            small2.SetParent(activeStorage);
        }
    }

    void SetParentOnDestruction(){
        if (gameObject.CompareTag("big")){
            gameObject.transform.SetParent(bigStorage);
        }
        else if (gameObject.CompareTag("medium")){
            gameObject.transform.SetParent(mediumStorage);
        }
        else if (gameObject.CompareTag("small")){
            gameObject.transform.SetParent(smallStorage);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("limits")){
            isWarpable=true;
        }
        else if(other.CompareTag("bullet")){
            ActivateAsteroids();
            SetParentOnDestruction();
            gameObject.transform.position = new Vector3(-9,-10,0);
            gameObject.SetActive(false);
        }
    }
}
