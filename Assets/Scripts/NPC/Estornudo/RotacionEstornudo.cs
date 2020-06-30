using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEstornudo : MonoBehaviour
{
    public float frequency = 1f;
    public float rotation = 0.15f;
    public float destroyTime = 5;

    public Sprite[] sprites;

    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void Update()
    {

        Color tmp = transform.GetComponent<SpriteRenderer>().color;
        tmp.a = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * 0.25f + 0.5f;
        transform.GetComponent<SpriteRenderer>().color = tmp;

        transform.Rotate(new Vector3(0f, 0f, rotation));

        Destroy(gameObject, destroyTime);
    }
}
