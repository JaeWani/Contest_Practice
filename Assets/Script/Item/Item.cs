using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D Rb;
    void Start(){
        Rb= GetComponent<Rigidbody2D>();
        Rb.velocity = new Vector2(0, -2);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        Used();
    }
    protected virtual void Used(){
        Debug.Log("Item Used!");
    }
}
