using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10; 
    void Start()
    {
    }
    void Update()
    { 
        Debug.Log("la velocidad actual es de" + moveSpeed);
        Movimiento();
    }
    void Movimiento()
    {
        //para moverse hacia adelante
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed,Space.World);
        }
        //izquierda
       if(Input.GetKey(KeyCode.A))
       {
        //----para delimitar que el jugador no pase los límites de la pista
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
//----COLISIONES----
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Obstacle"))
        {
            StartCoroutine(DisminuyeVelocidad(5, 2f)); // Reduce velocidad a 5 por 2 segundos

        }
    }
//----CAMBIOS DE VELOCIDADES----
    void AumentoVelocidad()
    {
        if(moveSpeed<14)
        {
            Debug.Log("al jugador se le aumenta la velocidad");
            moveSpeed +=1;
        }
    }
// CORRUTINA PARA DISMINUIR LA VELOCIDAD
    IEnumerator DisminuyeVelocidad(float nuevaVelocidad, float duracion)
    {
        Debug.Log("La velocidad se reduce temporalmente");
        moveSpeed = nuevaVelocidad;
        yield return new WaitForSeconds(duracion); 
        moveSpeed = 10;
        Debug.Log("Velocidad restaurada");
    }
}
