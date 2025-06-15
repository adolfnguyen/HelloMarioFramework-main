using System.Collections;
using System.Collections.Generic;
using HelloMarioFramework;
using UnityEngine;

public class BoxFall : TriggerObject
{
    Rigidbody rb;
    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Initially set to kinematic
            rb.useGravity = false; // Disable gravity initially
        }
    }
    protected override void OnTriggerStart()
    {
        Debug.Log("BoxFall Triggered");
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.down * 10f, ForceMode.Impulse);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(rb.velocity.magnitude >0.2f)
        {
                Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {

                Debug.Log("BoxFall collided with Player");
                player.Hurt(false, Vector3.back); // Assuming you want to kill the player on collision
                Destroy(gameObject); // Destroy the box after collision
            }
        }
       
    }
}
