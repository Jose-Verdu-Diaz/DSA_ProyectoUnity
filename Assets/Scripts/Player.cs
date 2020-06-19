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

    //Conteo Puntos
    public GameObject pointsDisplay;
    private int points;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidBody = GetComponent<Rigidbody2D>();

        healthBar = GameObject.Find("Healthbar");

        //Conteo Puntos
        pointsDisplay = GameObject.Find("Points");
        points = 0;
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
            int valor = collision.gameObject.GetComponent<Item>().getValor();
            pointsDisplay.GetComponent<Points>().addPoints(valor);
            points += valor;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Estornudo") healthBar.GetComponent<Healthbar>().TakeDamage(1);
    }
}
