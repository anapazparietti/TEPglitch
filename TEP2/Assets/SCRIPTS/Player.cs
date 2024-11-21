using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3; 


    void Start()
    {
    }
    void Update()
    { //movimiento automatico para adelante
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //------para moverse a los costados-----
        //izquierda
       if(Input.GetKey(KeyCode.A))
       {
        //if(this.gameObject.transform.position.x > LevelBoundary.leftSide)
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
       }
       //derecha
        if(Input.GetKey(KeyCode.D))
       {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed * -1);
       }

    }

}
