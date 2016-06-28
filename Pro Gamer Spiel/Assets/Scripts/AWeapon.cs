using UnityEngine;
using System.Collections;

public abstract class AWeapon : MonoBehaviour 
{
    protected AEntity m_owner;

    public int m_Damage;
    public int m_CurrentAmmunition;
    public int m_MagazineCap;
    public int m_MaxAmmo;
    public int m_MaxSpreadRadius;

    public float m_WeaponCoolDown;

    protected virtual void Awake()
    {
        m_owner = GetComponent<AEntity>();
    }

    public virtual void Shoot(Vector3 _start, Vector3 _dir)
    {
        if (m_WeaponCoolDown <= 0)
        {
            float randomRadius = m_MaxSpreadRadius;
            randomRadius = Random.Range(0, m_MaxSpreadRadius);


            float randomAngle = Random.Range(0, 2 * Mathf.PI);

            Vector3 direction = new Vector3(
                randomRadius * Mathf.Cos(randomAngle),
                randomRadius * Mathf.Sin(randomAngle),
                15);

            direction = this.transform.TransformDirection(direction.normalized);

            RaycastHit hit;
            Ray ray = new Ray(this.transform.position, direction);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Enemy")
                {
                    Debug.Log(hit.transform.name + " " + hit.point);
                }
            }

            m_CurrentAmmunition--;
        }

        
    }

    public virtual void Reload()
    {
        if (m_CurrentAmmunition == m_MagazineCap || m_MaxAmmo <= 0)
        {
            return;
        }

        if (m_MaxAmmo < m_MagazineCap && m_CurrentAmmunition + m_MaxAmmo <= m_MagazineCap)
        {
            m_CurrentAmmunition += m_MaxAmmo;
            m_MaxAmmo = 0;
            return;
        }
        m_MaxAmmo -= m_MagazineCap - m_CurrentAmmunition;
        m_CurrentAmmunition += m_MagazineCap - m_CurrentAmmunition;
    }
}