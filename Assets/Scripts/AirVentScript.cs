using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class AirVentScript : MonoBehaviour
{
    [SerializeField] public GameObject Fx;
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate air vent
        Instantiate(Fx, this.transform.position,this.transform.rotation);
        Fx.transform.localScale.Set((float)1.5,(float)1.5,(float)1.5);
    }

    private void OnTriggerStay(Collider other)
    {
        ThrowAir(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ThrowAir(other.gameObject);
    }

    private void ThrowAir(GameObject colObj)
    //event to move ball up when in zone
    {
        try
        {
            
            var colObjRB = colObj.GetComponent<Rigidbody>();
            /*
            float colObjPosY = colObj.GetComponentInParent<Transform>().position.y +
                               colObj.GetComponent<Transform>().position.y;
            */
            //We wanted to vary the force applied depending on the distance to the pivot of the fan, but we cut it because of delivery times
            float forceY = 45f;
            colObjRB.AddForce(new Vector3(0,forceY,0));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}
