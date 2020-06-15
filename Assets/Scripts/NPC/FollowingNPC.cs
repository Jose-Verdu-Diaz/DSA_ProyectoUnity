using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingNPC : MonoBehaviour
{
    private Vector3 heading;
    public Transform player;
    public float maxDistance;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if (!player) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        heading = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, heading.normalized, maxDistance);

        if (hit.collider != null)
            if (hit.transform == GameObject.FindGameObjectWithTag("Player").transform)
                rb.velocity = heading.normalized*3.2f;
            else
                rb.velocity = new Vector2(0f, 0f);
        else
            rb.velocity = new Vector2(0f, 0f);
    }
}
