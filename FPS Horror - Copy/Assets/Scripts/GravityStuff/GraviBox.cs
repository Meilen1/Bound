using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviBox : MonoBehaviour
{
    //este script se lo adjuntas a una caja que tenga gravedad loca.
    //acordate de cargar en el inspector qu� interactable le va a togglear la grav, y cuales son sus gravedad normal y loca.

    //-por valen y dk

    public Vector3 normalGrav;
    public Vector3 alteredGrav;

    private Vector3 appliedGrav;
    private bool isBound;
    private Rigidbody rb;

    void Start()
    {
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }

        appliedGrav = normalGrav;
        isBound = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        rb.AddForce(appliedGrav, ForceMode.Force); //aplica appliedGrav constantemente
    }

    public void ToggleGrav()
    {
        if (isBound)
        {
            appliedGrav = alteredGrav; //suelto a la caja para que flote (altero la grav)
            isBound = false;
        }
        else
        {
            appliedGrav = normalGrav; //la vuelvo a la normalidad
            isBound = true;
        }
    }
}
