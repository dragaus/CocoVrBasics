using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    Transform target;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[index];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((target.position - transform.position).normalized * 1 * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            index++;
            if (index >= waypoints.Count)
            {
                index = 0;
            }

            target = waypoints[index];
        }
    }
}
