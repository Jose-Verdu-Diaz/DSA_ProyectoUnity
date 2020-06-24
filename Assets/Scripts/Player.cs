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
    private int numObjects;

    public PauseMenu pauseScript;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidBody = GetComponent<Rigidbody2D>();

        healthBar = GameObject.Find("Healthbar");

        //Conteo Puntos
        pointsDisplay = GameObject.Find("Points");
        this.points = 0;
        this.numObjects = 0;

        pauseScript = GameObject.Find("ButtonPausa").GetComponent<PauseMenu>();
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
            this.points += valor;
            this.numObjects++;
        }
        else if (collision.tag == "Exit" && points > 0)
        {
            pauseScript.finalizar();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Estornudo") healthBar.GetComponent<Healthbar>().TakeDamage(1);
    }

    public int getPoints() { return this.points; }
    public int getNumObjects() { return this.numObjects; }
}
