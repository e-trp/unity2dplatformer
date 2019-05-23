using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{

    //public Transform playerCheck;
    public float speed;
    public Transform playerCheck;
    public GameObject enemy;
    public AudioSource capitanSound;
    private Rigidbody2D rb2d;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.left;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb2d.velocity = direction * speed;
        RaycastHit2D hit = Physics2D.Raycast(playerCheck.position, Vector2.down);

        if (hit.collider == true && hit.collider.tag == "Player")
        {
            Debug.Log("Eagele cast to " + hit.collider.tag);
            GameObject papuas = Instantiate(enemy, playerCheck.position, Quaternion.identity);
            papuas.transform.position = new Vector3(papuas.transform.position.x, papuas.transform.position.y, 0);
            capitanSound.Play();
        }

    }
}
