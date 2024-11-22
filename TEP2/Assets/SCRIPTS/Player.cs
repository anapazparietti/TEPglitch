using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7; 


    void Start()
    {
    }
    void Update()
    { //------MOVIMIENTO-----
        //para moverse hacia adelante
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed,Space.World);
        }
        //para moverse hacia los costados
        //izquierda
       if(Input.GetKey(KeyCode.A))
       {
        //para delimitar que el jugador no pase los límites de la pista
        if(this.gameObject.transform.position.x > LevelBoundary.leftSide){
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
       }
       //derecha
        if(Input.GetKey(KeyCode.D))
       {
        if(this.gameObject.transform.position.x < LevelBoundary.rightSide)
        {
         transform.Translate(Vector3.left * Time.deltaTime * moveSpeed * -1);
        }
       }

    }

}
