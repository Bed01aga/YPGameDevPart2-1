using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveElevator : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 0.5f;
    public bool hasSignal = false;

    private float startTime;
    private float journeyLength;

    void Start()
    {
        // Calculate the journey length between the two points
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        Debug.Log(journeyLength);

        // Record the start time
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (hasSignal)
        {
            // Calculate the distance covered so far

            // Calculate the fraction of the journey completed
            float fractionOfJourney = Mathf.PingPong(Time.time * speed, 1.0f);

            // Move the object between the two points using Lerp
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);
        }
       
    }

    public void Do()
    {
        hasSignal = true;
    }
}
