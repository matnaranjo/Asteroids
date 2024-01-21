
using UnityEngine;


public class Movement : MonoBehaviour
{
    float step=3.0f;
    Inputs playerInputs;
    Rigidbody2D playerRB;

    Vector3 components;
    public Vector3 Components{
        get{return components;}
    }

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
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        Warp.Warping(gameObject);
        Direction();
    }


    /// <summary>
    /// Takes the value of WASD, arrows or joystick inputs and adds a force in that direction to the spaceship 
    /// </summary>
    private void PlayerMovement(){
        Vector3 dir = playerInputs.Player.Movement.ReadValue<Vector2>();
        playerRB.AddForce(dir*step, ForceMode2D.Force);
    }

    private void Direction(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(playerInputs.Player.Direction.ReadValue<Vector2>());
        Vector2 playerPos = gameObject.transform.position;
        Vector2 distance = mousePos - playerPos;
        components = distance;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        gameObject.transform.eulerAngles = new Vector3(0,0,angle);

    }
}
