using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> beatenStructure = new List<GameObject>();
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Structure")
        {
            Debug.Log("Objeto Derribado");
            
        }
    }
}
