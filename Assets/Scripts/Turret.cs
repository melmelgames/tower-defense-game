﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject target;
    [Header("Attributes")]
    [SerializeField] private float range = 15f;
    [SerializeField] private float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Unity Setup Fields")]
    [SerializeField] private string enemyTag = "Enemy";
    private float lerpSpeed = 10f;

    public Transform partToRotate;
    public Transform firePoint;
    public GameObject bulletPrefab;
    

    private void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortedtDistanceToAnEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortedtDistanceToAnEnemy){
                shortedtDistanceToAnEnemy = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortedtDistanceToAnEnemy <= range){
            target = nearestEnemy;
        }else{
            target = null;
        }

    }

    private void Update(){
        if(target == null){
            return;
        }
        // Target look on
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * lerpSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f){
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot(){
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null){
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        
    }
}
