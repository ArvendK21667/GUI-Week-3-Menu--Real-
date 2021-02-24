using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePoint : MonoBehaviour
{

    public Transform[] waypoints;

    public float speed = 10f;

    public int currentwaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;



        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypoint].position, step);

        float distanceTowayPoint = Vector2.Distance(transform.position, waypoints[currentwaypoint].position);

        if (distanceTowayPoint < 0.2f) 

            currentwaypoint = currentwaypoint + 1;

    

        
        {
            //How we are at the waypoint
        }

            //currentwaypoint++;

            //how many waypoints are in the array
            //waypoints.length
    }
}
