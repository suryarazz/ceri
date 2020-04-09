using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isTouched;
    private int jump;
    public int jumpvalue;
    public Transform check;
    public float checkradius;
    public LayerMask whatisTouched;

    // Start is called before the first frame update
    void Start()
    {
        jump = jumpvalue;

        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if(isTouched == true)
        {
            jump = jumpvalue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && jump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            jump--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && jump==0 && isTouched == true)
            {
            rb.velocity = Vector2.up * jumpforce;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isTouched = Physics2D.OverlapCircle(check.position,checkradius,whatisTouched); 
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            jump = jumpvalue;
        }
        if (collision.gameObject.tag == "Crock")
        {
            
        }
    }
}
