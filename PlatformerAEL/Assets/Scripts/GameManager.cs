using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 ultimoCheckpoint;

    // Encapsulamiento - - - - - - - - - - - - - - -
    public Vector3 UltimoCheckpoint { get => ultimoCheckpoint; set => ultimoCheckpoint = value; }

    //------------------------------------------------------

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //------------------------------------------------------

    void Start()
    {
        //Seteamos el �ltimo Checkpoint como la posici�n de inicio del jugador.
        UltimoCheckpoint = GameObject.Find("Player").transform.position;
    }

    //----------------------------------------------------------
  
    void Update()
    {
        
    }

    //-------------------------------------------------------------

    public void EvaluarYActualizarCheckpoint(Vector3 nuevoCheckpoint)
    {
        //Si este Checkpoint est� m�s adelante que el anteriormente guardado
        if (nuevoCheckpoint.x > UltimoCheckpoint.x)
        {
            //Hacemos que el GameManager registre este Checkpoint como el �ltimo.
            UltimoCheckpoint = nuevoCheckpoint;
            print("Checkpoint actualizado");
        }
    }
}
