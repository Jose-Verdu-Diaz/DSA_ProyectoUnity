using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource ItemPickup;

    protected Joystick joystick;
    Rigidbody2D rigidBody;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * 4f, joystick.Vertical * 4f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {     
        if (other.tag == "Item")
        {
            other.gameObject.SetActive(false);
            ItemPickup.Play();
            Debug.Log("Objeto recogido");
        }
    }
}
