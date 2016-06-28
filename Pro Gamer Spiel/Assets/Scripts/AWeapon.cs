using UnityEngine;
using System.Collections;

public abstract class AWeapon : MonoBehaviour 
{
    protected AEntity m_owner;

    public int m_Damage;
    public int m_CurrentAmmunition;


    protected virtual void Awake()
    {
        m_owner = GetComponent<AEntity>();

    }

    public abstract void Shoot(Vector3 _start, Vector3 _dir);
}
