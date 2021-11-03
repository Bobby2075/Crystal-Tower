using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Transform target;
    private Rigidbody rb;

    public float speed = 70f;
    public void seek(Transform _target) {
        target = _target;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget() {

        Destroy(gameObject);
    }
}
