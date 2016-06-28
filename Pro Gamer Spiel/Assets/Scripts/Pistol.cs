using UnityEngine;
using System.Collections;
using System;

public class Pistol : AWeapon 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public override void Shoot(Vector3 _start, Vector3 _dir)
    {
        /*
Der Bereich wo der Schuss hinfallen kann wird zufällig gesetzt
            float randomRadius = maxSpreadRadius;
randomRadius = Random.Range(0, maxSpreadRadius);

            // Der Winkel und die tatsächliche Richtung des Schusses wird gesetzt
            float randomAngle = Random.Range(0, 2 * Mathf.PI);

Vector3 direction = new Vector3(
    randomRadius * Mathf.Cos(randomAngle),
    randomRadius * Mathf.Sin(randomAngle),
    15);

direction = Camera.main.transform.TransformDirection(direction.normalized);

            // Der eigentliche Schuss findet hier statt
            RaycastHit hit;
Ray ray = new Ray(Camera.main.transform.position, direction);

            if (Physics.Raycast(ray, out hit))
            {
                gc.bulletPoint.transform.position = hit.point;
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyController>().TakeDamage();
                }
            }
            */
    }
}
