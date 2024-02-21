using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Transform myCheckpoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            GameState.currentCheckpoint = collision.gameObject;
            Debug.Log(GameState.currentCheckpoint.gameObject.name);
        }



        if (collision.gameObject.tag == "EndPlane")
        {
            myCheckpoint = GameState.currentCheckpoint.transform.Find("CheckpointPlacement"); ;

            if (myCheckpoint != null)
            {
                this.transform.position = myCheckpoint.position;
            }
            else
            {
                Debug.Log("Checkpoint is null");
            }
        }
    }
}
