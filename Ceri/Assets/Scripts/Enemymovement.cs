using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public float speed;

    private bool move_right = true;
    public Transform groundDetection;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Edge")
        {
            if (move_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                move_right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                move_right = true;

            }
        }
    }
}
