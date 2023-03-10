using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit,1,layer))
        {
            if(Vector3.Angle(transform.position-previousPosition,hit.transform.up)>130)
            {
                Destroy(hit.transform.gameObject);
            }
        }
        previousPosition = transform.position;
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider e)
    {
        
    }
}
