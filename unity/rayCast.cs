using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    // Update is called once per frame
    public ParticleSystem muzzleFlash;
    public GameObject particals;
    public float impactForce;
    public float fireRate = 15f;

    private float NextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            AimNshoot();
        }
        
    }
    void AimNshoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range)){
            Debug.Log(hit.transform.name);
            Attack_life target = hit.transform.GetComponent<Attack_life>();
            if(target != null){

                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject inmpactGo = Instantiate(particals, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(inmpactGo, 2f);
        }
    }
}
