using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update    public Transform target;
    Vector3 tempVec3 = new Vector3();

    //public Transform target; // Quem queremos seguir
    public float smoothSpeed = 0.125f; // Velocidade que vai seguir

    // Logo depois
    void LateUpdate(){

        tempVec3.x = target.position.x;
        tempVec3.y = target.position.y;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;

    }
}
