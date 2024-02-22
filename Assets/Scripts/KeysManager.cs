using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class KeysManager : MonoBehaviour
{
    private float rotationsPerMinute = 20;
    public GameObject door;

    private void Update()
    {
        transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.GetComponent<DoorManager>().canBeOpen = true;  
            Destroy(this.gameObject);
        }
    }
}
