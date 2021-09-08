using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallScript : MonoBehaviour
{
    [SerializeField] public Vector3 velocidad = new Vector3(0,5,0);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= velocidad * Time.deltaTime;
        if (transform.position.y <= -0.9)
        {
            velocidad = velocidad * -1;
        }
        if (transform.position.y >= 5)
        {
            velocidad = velocidad * -1;
        }
    }
}
