using System.Collections.Generic;
using UnityEngine;

public class SC_RigidbodyMagnet : MonoBehaviour
{
    [SerializeField] public float magnetForce;
    [SerializeField] public GameObject fx;

    List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();

    void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            if (caughtRigidbodies[i])
            {
                float ForceX = (transform.position.x - (caughtRigidbodies[i].transform.position.x + caughtRigidbodies[i].centerOfMass.x)) * magnetForce * 2 * Time.deltaTime;
                float ForceY = (transform.position.y - (caughtRigidbodies[i].transform.position.y + caughtRigidbodies[i].centerOfMass.y)) * magnetForce * Time.deltaTime;
                caughtRigidbodies[i].AddForce(ForceX,ForceY,0);   
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();
            if(!caughtRigidbodies.Contains(r))
            {
                //Add Rigidbody
                caughtRigidbodies.Add(r);
                Instantiate(fx, other.transform.position,other.transform.rotation);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();

            if (caughtRigidbodies.Contains(r))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(r);
                Instantiate(fx, other.transform.position,other.transform.rotation);
            }
        }
    }
}