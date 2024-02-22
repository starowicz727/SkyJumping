using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Portal : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position= destination.position;
        }
    }
}
