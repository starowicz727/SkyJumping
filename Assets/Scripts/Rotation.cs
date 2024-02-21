using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationsPerMinute=10;
    [SerializeField] private int timerLeft = 200;
    [SerializeField] private int timerRight = 0;
    [SerializeField] private int swingTime = 400;
    private bool toTheLeft = true;
    [SerializeField] private int whichRotation = 0; //0=cradlex()

    private const float secondsOnStop = 1f;
    private float stopTimer = secondsOnStop;

    private void Start()
    {
    }

    void Update()
    {
        if(whichRotation==0)
        {
            CradleX();
        }
        else if(whichRotation==1)
        {
            CradleY();
        }
        else
        {
            CradleZ();
        }
    }
    void CradleX()
    {
        if (toTheLeft)
        {
            if (timerLeft < swingTime)
            {
                transform.Rotate(rotationsPerMinute * Time.deltaTime, 0, 0);
                timerLeft++;
            }
            else if(timerLeft >= swingTime && stopTimer>0)
            {
                stopTimer -= Time.deltaTime;
            }
            else
            {
                toTheLeft = false;
                timerLeft = 0;
                stopTimer = secondsOnStop;
            }
        }
        else
        {
            if (timerRight < swingTime)
            {
                transform.Rotate(-rotationsPerMinute * Time.deltaTime, 0, 0);
                timerRight++;
            }
            else if (timerRight >= swingTime && stopTimer > 0)
            {
                stopTimer -= Time.deltaTime;
            }
            else
            {
                toTheLeft = true;
                timerRight = 0;
                stopTimer = secondsOnStop;
            }
        }
    }

    void CradleY()
    {
        if (toTheLeft)
        {
            if (timerLeft < swingTime)
            {
                transform.Rotate(0, rotationsPerMinute * Time.deltaTime, 0);
                timerLeft++;
            }
            else
            {
                toTheLeft = false;
                timerLeft = 0;
            }
        }
        else
        {
            if (timerRight < swingTime)
            {
                transform.Rotate(0, -rotationsPerMinute * Time.deltaTime, 0);
                timerRight++;
            }
            else
            {
                toTheLeft = true;
                timerRight = 0;
            }
        }
    }

    void CradleZ()
    {
        if (toTheLeft)
        {
            if (timerLeft < swingTime)
            {
                transform.Rotate(0, 0, rotationsPerMinute * Time.deltaTime) ;
                timerLeft++;
            }
            else
            {
                toTheLeft = false;
                timerLeft = 0;
            }
        }
        else
        {
            if (timerRight < swingTime)
            {
                transform.Rotate( 0, 0, - rotationsPerMinute * Time.deltaTime);
                timerRight++;
            }
            else
            {
                toTheLeft = true;
                timerRight = 0;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player enter ");
            collision.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player ext ");
            collision.transform.parent = null;
        }
    }
}
