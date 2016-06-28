using UnityEngine;
using System.Collections;

public class LaserGun : AWeapon {
	
    private float damage;

    public override void Shoot(Vector3 _start, Vector3 _dir){

        Ray ray = new Ray(_start, _dir);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            AEntity entity = transform.gameObject.GetComponent<AEntity>();

            if (entity != null) {
                
                entity.TakeDamage(damage * Time.deltaTime);
            }
        }
    }
}