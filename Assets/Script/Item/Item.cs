using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        Used();
    }

    protected virtual void Used(){
        Debug.Log("Item Used!");
        
    }
}
