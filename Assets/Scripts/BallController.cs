using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Object = System.Object;
using Timer = System.Threading.Timer;

public class BallController : MonoBehaviour
{
    //private
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    //public
    public static Rigidbody rb;
    public bool isShoot = false;
    [SerializeField] public GameObject exitFX;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        isShoot = false;
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }

    private float forceMultiplier = 3;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;
        
        rb.AddForce(new Vector3(Mathf.Clamp(Force.x, Force.x, 350), Mathf.Clamp(Force.y, Force.y, 350), 0) * forceMultiplier);
        isShoot = true;
        BallSpawner.Instance.NewSpawnRequest();
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject, 5);
        InvokeRepeating("showDestroyFx", 4.9f, 9000f);
    }

    private void showDestroyFx()
    {
        Instantiate(exitFX,this.transform.position,Quaternion.Euler(-90,0,0));
    }

}
