using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : Monster
{
    Rigidbody2D _RB;

    [SerializeField] float MoveSpeed;
    private void Start() {
        _RB = GetComponent<Rigidbody2D>();

        //밑으로 이동하도록 velocity 설정
        _RB.velocity = new Vector2(0,-1 * MoveSpeed);
    }
    private void Update() {

    }
}
