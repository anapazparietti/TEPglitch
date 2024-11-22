using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10; 
    //para luego realizar el aumento de velocidad
     private float lastIncreaseTime = 0f;
     public float increaseInterval = 1;
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
            // Aumenta la velocidad si se cumple el intervalo
            if (Time.time - lastIncreaseTime > increaseInterval)
            {
                AumentoVelocidad();
                lastIncreaseTime = Time.time; // Actualiza el tiempo del último aumento
            }else if (Time.time - lastIncreaseTime > increaseInterval)
            {
                moveSpeed = Mathf.Max(10, moveSpeed - 1 * Time.deltaTime); // Baja la velocidad gradualmente

            }
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
