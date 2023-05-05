using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Vector3 ultimoCheckpoint;

    //Creamos un Manejador de Eventos para los Eventos de Da�o.
    public event EventHandler OnPlayerDamage;
    public event EventHandler OnEnemyDamage;

    // Encapsulamiento - - - - - - - - - - - - - - -
    public Vector3 UltimoCheckpoint { get => ultimoCheckpoint; set => ultimoCheckpoint = value; }


    //------------------------------------------------------

    void Awake()
    {
        Instance = this;
    }

    //------------------------------------------------------

    void Start()
    {
        //Seteamos el �ltimo Checkpoint como la posici�n de inicio del jugador.
        UltimoCheckpoint = GameObject.Find("Player").transform.position;
    }

    //-------------------------------------------------------------

    public void PlayerDamage()
    {
        //Si se ejecuta el Evento, este objeto disparar� una observaci�n, con argumentos vacios
        OnPlayerDamage?.Invoke(this, EventArgs.Empty);
    }

    //-------------------------------------------------------------

    public void EnemyDamage()
    {
        //Si se ejecuta el Evento, este objeto disparar� la observaci�n, con arhumentos vacios
        OnEnemyDamage?.Invoke(this, EventArgs.Empty);
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
