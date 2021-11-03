using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Transform target;
    private Rigidbody rb;
    public float thrust = 20.0f;
    private float delay = 5f;
   

    public void seek(Transform _target) {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * thrust);


        Destroy(gameObject, 2.5f);
    }

    private void HitTarget() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player")
            Debug.Log("Hit");
    }

}
