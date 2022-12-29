using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameObject player;
    [SerializeField] float speed;
    [SerializeField] float range;
    
    private float distance; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, range);
        foreach(Collider2D elt in collider){
            if (elt.gameObject.CompareTag("Player")){
                Follow();
            }
        }
        
    }

    // private void OnTriggerEnter2D(Collider2D obj) {
    //     if(obj.gameObject.CompareTag("Player")){
    //         Follow();
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D obj) {
        
    // }

    private void Follow(){
        Debug.Log("Follow() called");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
