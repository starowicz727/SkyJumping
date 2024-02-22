using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneForPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.parent = null;
        }
    }
}
