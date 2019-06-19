using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    [SerializeField] int triggerTime;
    [SerializeField] float maxDistance;
    [SerializeField] float radius;
    [SerializeField] GameObject explosionAnimation;
    private Vector3 center;
    private bool triggered;
    private Collider[] hitColliders;

    private void Start()
    {
        setDamage((int)(Game_manager.instance.getZombieLife() * 1.5f));
        setFadingK(player_equipment.instance.getSelectedGun().getFadingCoefficient());
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed(), ForceMode.VelocityChange);
        triggered = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!triggered)
            explode();            
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(center, radius);

    }
    private void explode()
    {
        triggered = true;
        center = transform.position;
        
        Instantiate(explosionAnimation, transform.position, transform.rotation);
        explosionAnimation.GetComponent<ParticleSystem>().Play();
        hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders)
        {
            if (c.tag == "enemy")
            {
                Debug.Log("colliso");
                float offset = Vector3.Distance(center, c.gameObject.transform.position);
                c.gameObject.GetComponent<enemy_entity>().decLifePoints(Damage() - (int)(offset * FadingK()));
            }
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if (!triggered)
        {            
            if (Vector3.Distance(GameObject.Find("equipment").transform.position, transform.position) > maxDistance)
            {                
                GetComponent<Rigidbody>().velocity = new Vector3(0, -50, 0);
                explode();
            }
                
        }
    }

}
