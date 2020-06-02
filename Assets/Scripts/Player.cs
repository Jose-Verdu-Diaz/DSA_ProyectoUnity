using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource ItemPickup;

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
