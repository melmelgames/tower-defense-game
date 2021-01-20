using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 70f;
    public GameObject bulletImpactEffect;

    public void Seek (GameObject _target){
        target = _target.transform;
    }

    private void Update(){
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;
        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget(){
        GameObject bulletImpactEffectInstance = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(bulletImpactEffectInstance, 2f);

        Destroy(gameObject);

    }
}
