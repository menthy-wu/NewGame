using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Enemy : MonoBehaviour
{
    
    private GameObject player;
    GameObject range;
    [SerializeField] float speed;
    [SerializeField] float angle;
    
    private float distance; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        range = transform.Find("range").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void faceTowards(GameObject Target) 
    {
        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }

    public void Follow(){
        faceTowards(player);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
