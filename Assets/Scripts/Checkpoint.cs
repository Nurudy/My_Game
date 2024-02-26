using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private GAMEMANAGER gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GAMEMANAGER>(); //de esta froma accedemos al estado del gamemanager, que
        //contiene la informacion del checkpoint
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {

        }
    }
}
