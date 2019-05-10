using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public Transform groundDetection;
    public float distance;
    private bool movingRight = true;
    private Rigidbody2D rb2d;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = Vector2.right * speed;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
        }
    }
}
