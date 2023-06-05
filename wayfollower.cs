using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayFollower : MonoBehaviour
{
    [SerializeField] GameObject[] ways ;
    int currentWayIndex = 0;
    [SerializeField] float sp = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, ways[currentWayIndex].transform.position) < 0.1f)
        {
            currentWayIndex++;
            if (currentWayIndex >= ways.Length)
            {
                currentWayIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, ways[currentWayIndex].transform.position, sp * Time.deltaTime);

    }
}
