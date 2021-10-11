using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShoot : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float turnSpeed = 10f;

    [Header("Other stuff")]
    public string playerTag = "Player";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {

        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players) {

            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if(distanceToPlayer < shortestDistance) {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }

        if(nearestPlayer != null && shortestDistance <= range) {
            target = nearestPlayer.transform;
        } else {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
        

        if(fireCountdown <= 0f) {
            shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void shoot() {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if (bullet != null)
            bullet.seek(target);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
