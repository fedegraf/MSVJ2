using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    [SerializeField] public GameObject Fx;
    [SerializeField] public bool IsEntry;
    [SerializeField] public GameObject Exit;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Fx, GetComponentInParent<Transform>().position, GetComponentInParent<Transform>().rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        MoveBall(other.gameObject);
    }

    private void MoveBall(GameObject pelota)
    {
        if (IsEntry)
        {
            pelota.GetComponent<Transform>().position = Exit.GetComponent<Transform>().position;
            pelota.GetComponent<Transform>().rotation = Exit.GetComponent<Transform>().rotation;
            pelota.GetComponent<Rigidbody>().velocity *= -2;

                ;
        }
    }
}
