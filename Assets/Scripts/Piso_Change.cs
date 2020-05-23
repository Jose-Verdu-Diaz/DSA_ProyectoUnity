using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public Material infecado;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.tag == "Abuela")
        {
            this.GetComponent<Renderer>().material = infecado;
        }
   
     }


    // Update is called once per frame
    void Update()
    {
        
    }
}
