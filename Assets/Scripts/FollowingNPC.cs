using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingNPC : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float distancia;
    private Vector3 direction;
    public float moveSpeed = 5f;
    public float empezaSeguir;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update(){
        direction = player.position - transform.position;
        distancia = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        direction.Normalize();
        movement = direction;

        if (distancia <= empezaSeguir){
            rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
        }
    }
}
