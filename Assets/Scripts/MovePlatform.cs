using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
   
    public int positionOffset;
    Vector2 direction;
    int counter;
    public string moveType;


    // Start is called before the first frame update


    void Start()
    {
        if (moveType == "vertical")
            direction = Vector2.up;
        else if (moveType == "horizontal")
            direction = Vector2.left;

        counter=positionOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(direction * Time.deltaTime, Space.World);
        counter--;
        if (counter == 0)
        {
            direction *= -1;
            counter = positionOffset*2;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
            Debug.Log("player collision");
        }
    }
    void OnCollisionExit2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }

    }
}
