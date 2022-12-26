using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    public Rigidbody2D rb;
    [SerializeField] float speed;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        // rb.velocity = new Vector2(x * speed, y * speed);
        if(x > 0) {
            x = 1;
        }
        else if(x == 0){
            x = 0;
        }
        else {
            x = -1;
        }

        if(y > 0) {
            y = 1;
        }
        else if (y == 0){
            y=0;
        }
        else {
            y = -1;
        }
        rb.velocity = new Vector3(x * speed ,y * speed, 0);
    }

    void FixedUpdate() {
        
        // rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }
}
