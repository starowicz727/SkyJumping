using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class KeysManager : MonoBehaviour
{
    private float rotationsPerMinute = 20;

    private void Update()
    {
        transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorManager.canBeOpen = true;
            Destroy(this.gameObject);
        }
    }
}
