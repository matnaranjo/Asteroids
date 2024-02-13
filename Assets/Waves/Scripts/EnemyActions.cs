
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    float hp;
    float moveSpeed = 0;

    public float MoveSpeed{
        set{moveSpeed = value;}
    }
    float attackSpeed= 1;

    Enemy enemyAttributes;
    Transform player;

    void OnEnable(){
        SetValues();
    }
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        enemyAttributes = GameObject.FindGameObjectWithTag("enemystorage").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Update(){
        Death();
    }

    void SetValues(){
        hp = enemyAttributes.hp;
        moveSpeed = 1*enemyAttributes.moveSpeed;
        attackSpeed = 1*enemyAttributes.attackSpeed;
    }

    void Movement(){
        Vector3 dir = (player.position - gameObject.transform.position).normalized;
        if (dir.x<0){
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if (dir.x>0){
            transform.eulerAngles = new Vector3(0,0,0);
        }

        gameObject.transform.position += dir * moveSpeed * Time.fixedDeltaTime*1.5f;

    }

    public void DecreaseHP(){
        hp--;
    }


    void Death(){
        if(hp<=0){
            moveSpeed =0;
            transform.position = enemyAttributes.gameObject.transform.position;
            transform.SetParent(enemyAttributes.gameObject.transform);
        }
    }
}
