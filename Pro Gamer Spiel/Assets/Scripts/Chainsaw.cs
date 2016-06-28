using UnityEngine;
using System.Collections;

public class Chainsaw : AWeapon {

    private float maxDistance = 5;

    private float ammunitionSeconds = 0;

    private float audioStop = 0;

    private bool alreadyPlaying = false;

    void Awake(){

        base.Awake();

        m_Damage = 35;
        m_CurrentAmmunition = 15;
        m_MagazineCap = 15;
        m_MaxAmmo = 90;
    }

    void Update(){

        if (audioStop < 0) {

            AudioManager.StopChainsawShot();

            alreadyPlaying = false;
        }
        else {

            audioStop -= Time.deltaTime;
        }
    }

    public override void Shoot(Vector3 _start, Vector3 _dir){

        Ray ray = new Ray(_start, _dir);
        RaycastHit hit;

        ammunitionSeconds -= Time.deltaTime;

        if (!alreadyPlaying) {

            AudioManager.PlayChainsawShot();
            audioStop = 0.1F;
            alreadyPlaying = true;
        }
        else {

            audioStop = 0.1F;
        }

        if (ammunitionSeconds <= 0) {

            ammunitionSeconds += 1;
            m_CurrentAmmunition--;
        }

        if (m_CurrentAmmunition >= 0 && Physics.Raycast(ray, out hit)) {

            audioStop = 0.1F;

            if (Vector3.Distance(transform.position, hit.point) < maxDistance) {

                AEntity entity = transform.gameObject.GetComponent<AEntity>();

                if (entity != null) {

                    entity.TakeDamage(m_Damage * Time.deltaTime);
                }
            }
        }
    }
}