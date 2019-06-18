using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bullet
{
    [SerializeField] int triggerTime;
    [SerializeField] float maxDistance;
    [SerializeField] float radius;
    private Vector3 center;
    private bool triggered;
    private Collider[] hitColliders;

    private void Start()
    {
        setDamage(Game_manager.instance.getZombieLife() * 2);
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed(), ForceMode.VelocityChange);
        triggered = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        center = transform.position;
        triggered = true;
        Time().resetTimer();
    }
    private void explode()
    {
        hitColliders = Physics.OverlapSphere(center, radius);
        foreach (Collider c in hitColliders)
        {
            if (c.tag == "enemy")
            {
                float offset = Vector3.Distance(center, c.gameObject.transform.position);
                c.gameObject.GetComponent<enemy_entity>().decLifePoints(Damage() - (int)(offset * FadingK()));
            }
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Vector3.Distance(GameObject.Find("equipment").transform.position, transform.position) > maxDistance)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -50, 0);// Vector3.zero;

            if (triggered)
            {
                if (Time().triggeredValue() == 0)
                    Time().triggerTimer(triggerTime);
                else if (Time().triggeredValue() == 2)
                {
                    explode();
                    triggered = false;
                }
            }
        }
    }
    
}
