using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private float directionSpeed = 1f;
    private float startPosition;
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private bool goUp;
    [SerializeField] private bool toTheSide = true;

    
    private const float secondsOnStop = 1f;
    private float stopTimer = secondsOnStop;

    void Start()
    {
        if (toTheSide)
        {
            startPosition = this.transform.position.z;
        }
        else
        {
            startPosition = this.transform.position.y;
        }

    }

    void Update()
    {
        if (toTheSide)
        {
            ToTheSideMovement();
        }
        else
        {
            Movement();
        }

    }

    private void Movement()
    {
        if (goUp)
        {
            if (this.transform.position.y < startPosition + amplitude)
            {
                this.transform.position = transform.position + new Vector3(0, directionSpeed * Time.deltaTime, 0);
            }
            else if (this.transform.position.y > startPosition + amplitude && stopTimer>0)
            {
                stopTimer-= Time.deltaTime;
            }
            else
            {
                goUp = false;
                stopTimer = secondsOnStop;
            }
        }
        else
        {
            if (this.transform.position.y > startPosition - amplitude)
            {
                this.transform.position = transform.position - new Vector3(0, directionSpeed * Time.deltaTime, 0);
            }
            else if (this.transform.position.y < startPosition - amplitude && stopTimer > 0)
            {
                stopTimer -= Time.deltaTime;
            }
            else
            {
                goUp = true;
                stopTimer = secondsOnStop;
            }
        }
    }

    private void ToTheSideMovement()
    {
        if (goUp)
        {
            if (this.transform.position.z < startPosition + amplitude)
            {
                this.transform.position = transform.position + new Vector3(0, 0, directionSpeed * Time.deltaTime);
            }
            else if (this.transform.position.z > startPosition + amplitude && stopTimer > 0)
            {
                stopTimer -= Time.deltaTime;
            }
            else
            {
                goUp = false;
                stopTimer = secondsOnStop;
            }
        }
        else
        {
            if (this.transform.position.z > startPosition - amplitude)
            {
                this.transform.position = transform.position - new Vector3(0, 0, directionSpeed * Time.deltaTime);
            }
            else if (this.transform.position.z < startPosition - amplitude && stopTimer > 0)
            {
                stopTimer -= Time.deltaTime;
            }
            else
            {
                goUp = true;
                stopTimer = secondsOnStop;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player enter ");
            //collision.transform.parent = this.transform;
            collision.transform.SetParent(this.transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player ext ");
            collision.transform.parent = null;
            //collision.transform.SetParent(null, true);
        }
    }

}
