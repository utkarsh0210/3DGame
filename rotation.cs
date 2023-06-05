using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] float spX;
    [SerializeField] float spY;
    [SerializeField] float spZ;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * spX * Time.deltaTime, 360 * spY * Time.deltaTime, 360 * spZ * Time.deltaTime);
    }
}
