using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingUnitController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    Vector2 direction;
    public float speed;
    public float offset;
    float startPosition;
    float leftEnd;
    float rightEnd;
    float destinationPoint;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position.x;
        leftEnd = startPosition - offset;
        rightEnd = startPosition + offset;
        direction = Vector2.right;
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb2d.velocity = direction * speed;
        Physics2D.Raycast(transform.position, new Vector2(10, 0));
        
        if (offset > 5)
        {
            direction = direction * -1;

        }


    }
}
