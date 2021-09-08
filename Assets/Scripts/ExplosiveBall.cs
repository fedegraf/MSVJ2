using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBall : MonoBehaviour
{
    [SerializeField]private float radio;
    [SerializeField] private GameObject fx;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        
        foreach(Collider col in colliders)
        {
            Rigidbody body = col.attachedRigidbody;
            if (body != null)
            {
                Vector3 direction = body.transform.position - transform.position;
                body.AddForce(direction * 10f, ForceMode.Impulse);
            }
        }

        Instantiate(fx, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}
