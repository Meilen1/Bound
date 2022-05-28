using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : Collectables
{
    //cuando tocas E, levantas la linterna y desaperece el chebola colgante. 
    //por diego katabian

    public GameObject chebolaCrux;

    public override void Interact()
    {
        PlayerStats.instance.hasFlashlight = true; //obtengo la linterna
        Destroy(chebolaCrux, 0.1f); //destruye al chebola colgado
        base.Interact();
    }
}

