using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float hp=15;
    public float moveSpeed=0;
    public float attackSpeed=1;
    int spawn;

    EnemyActions [] enemies;
    Transform enemyAttacking;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        enemyAttacking = GameObject.FindGameObjectWithTag("enemyattacking").transform;
        spawn  = Random.Range(2, 6);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }


    IEnumerator Spawn(){
            enemies = gameObject.transform.GetComponentsInChildren<EnemyActions>();
        while (enemies.Length >0){
            enemies = gameObject.transform.GetComponentsInChildren<EnemyActions>();
            enemies[0].gameObject.GetComponent<EnemyActions>().MoveSpeed = 1;
            enemies[0].gameObject.transform.position = Random.insideUnitCircle.normalized * 9;
            enemies[0].gameObject.transform.SetParent(enemyAttacking);
            yield return new WaitForSeconds(spawn);
        }
    }
    
    
    
    
    public void RandomIncrease(){
        List<string> attributes = new List<string>();
        int randIndex;

        // Assign attributes that can improve
        attributes.Add("hp");
        if(moveSpeed<3){
            attributes.Add("moveSpeed");
        }
        if (attackSpeed<2){
            attributes.Add("attackSpeed");
        }

        randIndex = Random.Range(0, attributes.Count);

        if(attributes[randIndex]=="attackSpeed" && attackSpeed<3){
            attackSpeed += 0.2f;
        }
        else if (attributes[randIndex]=="moveSpeed" && moveSpeed<3){
            moveSpeed += 0.2f;
        }
        else{
            hp +=0.5f;
        }

    }
}
