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
    private float randomSteps=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        randomSteps = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (moving)
        {
            if (randomSteps>0)
            {
                rb.velocity = direction*moveSpeedMultiplicator;
                randomSteps-=Time.deltaTime;
            }
            else
            {
                moving = false;
                rb.velocity = new Vector2(0f,0f);
                randomSteps = Random.Range(1f, 3f);
            }
        }
        else
        {
            if (randomSteps > 0)
            {
                randomSteps -= Time.deltaTime;
            }
            else
            {
                direction = Random.insideUnitCircle.normalized;

                randomSteps = Random.Range(1f, 3f);
                moveSpeedMultiplicator = Random.Range(1f, 1.5f);

                moving = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            direction = Vector2.Perpendicular(direction);
        }
    }

}
