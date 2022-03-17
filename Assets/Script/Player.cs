using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private SpriteRenderer sprite;

    // variabel penentu
    private float horizontalValue;
    private const float gCheckRadius = 0.2f;
    private bool facingRigth = true;
    private bool IsRunning = false;
    private bool jumpdelay;
    private bool isGrounded = false;
    [SerializeField] private int Change;


    // variabel yang di serialisasi agar muncul di editor
    [SerializeField] private float speed = 5f;
    [SerializeField] private float runSpeed = 2f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private int Gem = 0;
    [SerializeField] Transform gCheckColl;
    [SerializeField] private Sprite Fire;
    [SerializeField] private Sprite Water;
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject Merah, Biru;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // input code a d
        horizontalValue = Input.GetAxisRaw("Horizontal");
        dash();
        lompat();
        Swap();
        Shoot();
    }

    private void FixedUpdate()
    {
        groundCheck();
        Move(horizontalValue);
    }

    //method bergerak
    private void Move(float dir)
    {
        //jika shift maka speed up
        if (IsRunning)
            dir *= runSpeed;
        //vector2 buat rb
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    
        //flip kiri 
        if(facingRigth && dir < 0)
        {
            Flip();
        }
        
        //flip kanan
        if(!facingRigth && dir > 0)
        {
            Flip();
        }

        //mengatur nilai xspeed berdasar nilai x rb
        anim.SetFloat("xspeed", Mathf.Abs(rb.velocity.x));
    }

    //method lompat
    private void lompat()
    {
        //tekan spasi dan menyentuh layer ground = lompat
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                //perpindahan vector 2 y.
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }

            //menjalankan fungsi jumpdelay
            else
            {
                if (jumpdelay)
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }
            }
        }

        // jika masih di ground animasi lompat = false
        if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("jump", false);
        }

        // jika tidak di ground animasi lompat = true;
        if (!coll.IsTouchingLayers(ground))
        {
            anim.SetBool("jump", true);
        }
            
    }

    //berfungsi sebagai delay agar bisa lompat ketika 
    //keluar dari layer ground
    IEnumerator JumpDelay()
    {
        jumpdelay = true;
        yield return new WaitForSeconds(0.2f);
        jumpdelay = false;
    }

    //method lari cepat
    private void dash()
    {
        //jika tekan shift 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsRunning = true;
        }

        //jika lepas shift
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsRunning = false;
        }
    }

    // method flip
    private void Flip()
    {
        // mengganti arah player melihat.
        facingRigth = !facingRigth;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sprite.sprite = Fire;
            Change = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            sprite.sprite = Water;
            Change = -1;
        }
    }

    private void groundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gCheckColl.position, gCheckRadius, ground);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            //Un-parent the transform
            transform.parent = null;

            if (wasGrounded)
                StartCoroutine(JumpDelay());
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Change > 0)
        {
            Instantiate(Merah, firePoint.position, firePoint.rotation);
        }
        if (Input.GetButtonDown("Fire1") && Change < 0)
        {
            Instantiate(Biru, firePoint.position, firePoint.rotation);
        }
    }
    //method ketika menyentuh objebt dengan tag PickUp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp")
        {
            // jika menyentuh maka object akan hancur dan gem bertambah 1
            Destroy(collision.gameObject);
            Gem += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            FindObjectOfType<LifeCount>().LoseLife();
        }
    }

    


}
