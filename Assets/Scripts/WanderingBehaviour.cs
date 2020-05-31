using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    public float moveSpeed = 5f;
    private float moveSpeedMultiplicator;

    private bool moving = false;
    private int randomSteps=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!moving && randomSteps==0)
        {
            direction = Random.insideUnitCircle.normalized;

            randomSteps = Random.Range(100,800);
            moveSpeedMultiplicator = Random.Range(0.5f, 2.5f);

            moving = true;
        }
        else if (!moving && randomSteps!=0)
        {
            randomSteps--;
        }

        if (moving && randomSteps!=0)
        {
            moveNPC(direction);
            randomSteps--;
        }
        else if(moving && randomSteps==0)
        {
            moving = false;
            randomSteps = Random.Range(100, 500);
        }
    }

    void moveNPC(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * moveSpeedMultiplicator * Time.deltaTime));
    }
}
