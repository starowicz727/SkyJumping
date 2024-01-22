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
            if (this.transform.position.y <= startPosition + amplitude)
            {
                this.transform.position = transform.position + new Vector3(0, directionSpeed * Time.deltaTime, 0);
            }
            else
            {
                goUp = false;
            }
        }
        else
        {
            if (this.transform.position.y >= startPosition - amplitude)
            {
                this.transform.position = transform.position - new Vector3(0, directionSpeed * Time.deltaTime, 0);
            }
            else
            {
                goUp = true;
            }
        }
    }

    private void ToTheSideMovement()
    {
        if (goUp)
        {
            if (this.transform.position.z <= startPosition + amplitude)
            {
                this.transform.position = transform.position + new Vector3(0, 0, directionSpeed * Time.deltaTime);
            }
            else
            {
                goUp = false;
            }
        }
        else
        {
            if (this.transform.position.z >= startPosition - amplitude)
            {
                this.transform.position = transform.position - new Vector3(0, 0, directionSpeed * Time.deltaTime);
            }
            else
            {
                goUp = true;
            }
        }
    }
}
