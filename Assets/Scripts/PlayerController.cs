using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    bool facingRight = true;
    Animator anim;
    Rigidbody2D rb2d;

  
    public Transform enemyCheck;
    public LayerMask whatIsEnemy;
    float enemyCheckRadius = 0.5f;


    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.1f;
    public LayerMask whatIsGround;
    public float jumpForce = 10f;

    public int numOfHearts;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;



    // Start is called before the first frame update


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb2d.velocity.y);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("To main menu");
            SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Player jump");
            anim.SetBool("Ground", false);
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Player fire");
            anim.Play("knight_sword_attack");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(enemyCheck.position, enemyCheckRadius, whatIsEnemy);
            foreach (Collider2D enemy in enemies)
            {
                Debug.Log("You hit object : " + enemy.name);
                enemy.gameObject.SetActive(false);
                Destroy(enemy);
            }

        }

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Update()
    {




    }

    void OnCollisionEnter2D(Collision2D col)
    {
      

        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collision ");
            if (health==1)
            {
                health--;
                updateHealth();
                anim.Play("knight_die");
                
            }
            else
            {
                
                health--;
                updateHealth();
            }



        }

        if (col.gameObject.tag == "Potion")
        {

            Debug.Log("Potion collision");
            Destroy(col.gameObject);
            if (hearts.Length > health)
            {
                health++;
                updateHealth();
            }
            
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void updateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}