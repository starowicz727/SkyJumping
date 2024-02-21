using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static bool canBeOpen = false;
    public GameObject blockingPlane;
    private float timer = 5;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (canBeOpen)
            {
                if (timer>0)
                {
                    blockingPlane.SetActive(false);
                    this.transform.Rotate( 0, 0, -20 * Time.deltaTime);
                    timer -= Time.deltaTime;
                }
            }
        }
        
    }
}
