using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("Variables principales:")]
    public string nombre;
    public int valor;

    [Space]

    [Header("Efecto flotación:")]

    [Tooltip("Altura máxima del efecto (recomendado 0.2)")]  public float amplitude = 0.2f;
    [Tooltip("Frecuencia del efecto (recomendado 0.7)")] public float frequency = 0.7f;
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        //Efecto flotación
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    public int getValor() { return this.valor; }
}
