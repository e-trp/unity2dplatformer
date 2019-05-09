using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    bool EnemyHit;
    public LayerMask whatIsEnemy;


    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        EnemyHit = Physics2D.OverlapBox(player.transform.position, player.GetComponent<BoxCollider2D>().size, whatIsEnemy);
        if (EnemyHit)
        {
            Debug.Log("Health controller hit detect");
        }
        Debug.Log(player.name + " " + EnemyHit);

    }
}
