using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource ItemPickup;

    protected Joystick joystick;
    Rigidbody2D rigidBody;

    private int hp;

    public GameObject healthBar;
    public GameObject points;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidBody = GetComponent<Rigidbody2D>();

        healthBar = GameObject.Find("Healthbar");
        points = GameObject.Find("Points");
    }

    private void Update()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * 4f, joystick.Vertical * 4f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            collision.gameObject.SetActive(false);
            ItemPickup.Play();
            points.GetComponent<Points>().addPoints(100);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Estornudo") healthBar.GetComponent<Healthbar>().TakeDamage(1);
    }
}
