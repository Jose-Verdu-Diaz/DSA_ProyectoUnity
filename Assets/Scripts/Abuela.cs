using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abuela : MonoBehaviour
{

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float distancia;
    public float moveSpeed = 5f;
    public float empezaSeguir;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 direction = player.position - transform.position;
        // Converter em degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        distancia = Mathf.Abs(direction.x)+Mathf.Abs(direction.y);
        direction.Normalize();
        movement = direction;

    }

    private void Update(){
        if(distancia <= empezaSeguir){
            moveAbuela(movement);
        }
    }

    void moveAbuela(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
