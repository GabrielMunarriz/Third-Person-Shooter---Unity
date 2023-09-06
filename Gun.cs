using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private int damage = 25;
    private float timer;

    Ray ray;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform raycastDestination;

    [SerializeField] private ParticleSystem muzzleParticle;
    [SerializeField] private TrailRenderer tracerEffect;
    public GameObject impactEffect;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
        /* if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo, distance))
            {
                Health enemyHealth = hitInfo.collider.GetComponent<Health>();
                Animation enemyAnim = hitInfo.collider.GetComponentInChildren<Animation>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageAmount);
                }
                Debug.Log("Hit: " + hitInfo.collider.name);

                
                
            }
        } */
    }

    private void FireGun()
    {
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        muzzleParticle.Play();
        Ray ray = new Ray(firePoint.position, raycastDestination.position - firePoint.position);
        RaycastHit hitInfo;

        var tracer = Instantiate(tracerEffect, firePoint.position, Quaternion.identity);
        tracer.AddPosition(firePoint.position);

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGO, 2f);

            tracer.transform.position = hitInfo.point;

            Debug.Log("Hit: " + hitInfo.collider.name);
            Debug.DrawLine(firePoint.position, hitInfo.point, Color.red, 1.0f);
        }
    }
}
