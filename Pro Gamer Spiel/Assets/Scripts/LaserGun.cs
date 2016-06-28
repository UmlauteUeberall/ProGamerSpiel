using UnityEngine;
using System.Collections;

public class LaserGun : AWeapon {
	
    private float damage;

    public void Shoot(Vector3 _start, Vector3 _dir){

        Ray ray = new Ray(_start, _dir);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            transform.gameObject.GetComponent<AEntity>();
        }
    }
}