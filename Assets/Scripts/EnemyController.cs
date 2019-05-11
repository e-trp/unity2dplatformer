using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float enemySpeed;
    public Transform groundDetection;
    public float distance;
    private Rigidbody2D rb2d;
    private Vector2 direction;
    private RaycastHit2D groundInfo;
    private RaycastHit2D ceilingCheck;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.left;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = direction * enemySpeed;

        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        ceilingCheck = Physics2D.Raycast(groundDetection.position, Vector2.up, distance);
     
        if (groundInfo.collider == true)
        {
            Debug.Log(groundInfo.collider.name);
            if (groundInfo.collider.tag != "Ground" || ceilingCheck.collider == true)
            {
                changeDirection();
            }

        }

        else
        {
            changeDirection();


        }

    }

    protected void changeDirection()
    {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        direction = direction * -1;

    }
}
