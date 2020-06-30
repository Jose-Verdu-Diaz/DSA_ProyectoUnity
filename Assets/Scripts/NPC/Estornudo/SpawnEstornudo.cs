using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEstornudo : MonoBehaviour
{
    public GameObject estornudo;

    public bool enfermo = true;


    private Vector3 offset;
    private float pausaEstornudar;
    public int probEnfermo;

    private GameObject pausa;


    public AudioSource[] cough;

    // Start is called before the first frame update
    void Start()
    {
        pausa = GameObject.Find("ButtonPausa");

        pausaEstornudar = Random.Range(1f, 4f); ;


        int enfermoRange = Random.Range(1, 100);
        if (enfermoRange < probEnfermo)
        {
            enfermo = true;
        }
        else
        {
            enfermo = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausa.GetComponent<PauseMenu>().isPaused && enfermo)
        {
            if (pausaEstornudar <= 0)
            {
                cough[Random.Range(0, cough.Length)].Play();

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

                pausaEstornudar = Random.Range(6f, 9f);
            }
            else
            {
                pausaEstornudar -= Time.deltaTime;
            }
        }
    }
}
