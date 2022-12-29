using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    private TMP_Text score;
    private Rigidbody2D rb;
    int totalScore = 0;

    [SerializeField]
    float speed;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessCollision(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ProcessCollision(other.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Die();
            return;
        }
        if(collider.CompareTag("Collection"))
        {
            totalScore++;
            // Debug.Log(totalScore);
            score.text = totalScore.ToString();
            Destroy(collider);
        }
    }

    void Die() { 
        Debug.Log("die");
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
            x = -1;
        else if (Input.GetKey(KeyCode.D))
            x = 1;
        else
            x = 0;
        if (Input.GetKey(KeyCode.W))
            y = 1;
        else if (Input.GetKey(KeyCode.S))
            y = -1;
        else
            y = 0;
        rb.velocity = new Vector2(x, y).normalized * speed;
    }
}
