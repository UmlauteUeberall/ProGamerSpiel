using UnityEngine;
using System.Collections;

public class Chainsaw : AWeapon {

    private float maxDistance = 5;

    private float ammunitionSeconds = 0;

    void Awake(){

        base.Awake();

        m_Damage = 35;
        m_CurrentAmmunition = 15;
    }

    public override void Shoot(Vector3 _start, Vector3 _dir){

        Ray ray = new Ray(_start, _dir);
        RaycastHit hit;

        ammunitionSeconds -= Time.deltaTime;

        if (ammunitionSeconds <= 0) {

            ammunitionSeconds += 1;
            m_CurrentAmmunition--;
        }

        if (m_CurrentAmmunition >= 0 && Physics.Raycast(ray, out hit)) {

            if (Vector3.Distance(transform.position, hit.point) < maxDistance) {

                hit.transform.gameObject.GetComponent<AEntity>().TakeDamage(m_Damage * Time.deltaTime);
            }
        }
    }
}