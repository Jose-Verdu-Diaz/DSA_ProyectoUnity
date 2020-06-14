using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEstornudo : MonoBehaviour
{
    public GameObject estornudo;
    public bool enfermo = true;
    public int probabiliadEstornudo;
    private int p;
    private Vector3 offset;
    private int pausaEstornudar;

    // Start is called before the first frame update
    void Start()
    {
        pausaEstornudar = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausaEstornudar==0)
        {
            p = Random.Range(0,10000);
            if (p <= probabiliadEstornudo)
            {
                offset = transform.position;
                Instantiate(estornudo, offset, Quaternion.identity);
                offset.x = offset.x + 0.1f;
                Instantiate(estornudo, offset, Quaternion.identity);
                offset.x = offset.x - 0.2f;
                Instantiate(estornudo, offset, Quaternion.identity);
                offset.x = offset.x + 0.1f;
                offset.y = offset.y + 0.1f;
                Instantiate(estornudo, offset, Quaternion.identity);
                offset.y = offset.y - 0.2f;
                Instantiate(estornudo, offset, Quaternion.identity);

                pausaEstornudar = 1000;
            }
        }
        else
        {
            pausaEstornudar--;
        }
        
    }
}
