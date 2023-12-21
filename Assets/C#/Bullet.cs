using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce; 
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * bulletForce, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
