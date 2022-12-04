using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float maxSpeed;
    public float jumHeight;

    bool facingRight;
    bool grounded;

    //Khai bao cac bien de ban

    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    Rigidbody2D myBody;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D> ();
        myAnim = GetComponent<Animator> ();

        facingRight = true;


    }

    // Update is called once per frame
    void FixedUpdate() //FixedUpdate chiu tac dung nhưng doi tuong vat ly
    {
        float move = Input.GetAxis("Horizontal");  //tao bien move thuoc kieu so thuc, lay tư ban phim de di chuyen theo chieu ngang

        myAnim.SetFloat("speed", Mathf.Abs(move));      

        myBody.velocity = new Vector2(move*maxSpeed, myBody.velocity.y);

        if(move > 0 && !facingRight)
        {
            flip ();
        }else if(move < 0 && facingRight)
        {
            flip();
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumHeight);
            }
            
        }
        // Chuc nang ban tu ban phim
        //if (Input.GetAxisRaw("Fire1") > 0)
        if (Input.GetMouseButtonDown(0))
        {
            fireBullet();
        }

    }
    void flip()
    {
        facingRight = !facingRight; 
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D other) //va cham voi player mang ten gound 'nen dat' thi moi bay duoc
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    //Chuc nang ban
    void fireBullet() { 
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180 )));
            }
        }
    }
}
