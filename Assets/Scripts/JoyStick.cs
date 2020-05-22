using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{

    public Transform player;
    public float speed = 5.0f;
    public float movimentoJoy;
    private bool touchStart = false;

    private Vector2 pointA;
    private Vector2 pointB;


    public Transform circle;
    public Transform outerCircle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){

            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            
            circle.transform.position = new Vector2(pointA.x, pointA.y);
            outerCircle.transform.position = new Vector2(pointA.x, pointA.y);

            
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetMouseButton(0)){
            touchStart = true;

            pointB = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        }else{

            touchStart = false;
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }



    private void FixedUpdate(){

        if(touchStart){

            Vector2 offset = pointB - pointA;
            // Movimento
            Vector2 direction2 = Vector2.ClampMagnitude(offset, movimentoJoy);
            // Velocidade
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);

            circle.transform.position = new Vector2(pointA.x + direction2.x, pointA.y + direction2.y);
        }

    }

    void moveCharacter(Vector2 direction){

        player.Translate(direction * speed * Time.deltaTime);// suave durante os frames
     
    }




}