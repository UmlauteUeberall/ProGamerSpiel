using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour 
{
    public GameObject m_projectilePrefab;
    public float spawnInterwal = 1.0f;
    public GameObject FrontBarrel;
    private float m_time = 0f;
    public float timeOffset;
    public float m_BulletVelocity = 35f;
    public LayerMask m_ProjectilLayer;

    // Use this for initialization
    void Start () 
	{
        m_time -= timeOffset;
        
    }
	
	// Update is called once per frame
	void Update () 
	{
        Rotation();
        ProcessShot();
	}
    void Rotation()
    {
        transform.Rotate(new Vector3(1, 5, 3) * (Time.deltaTime));
    }
    void ProcessShot()
    {
        Ray ray = new Ray(FrontBarrel.transform.position, FrontBarrel.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, m_ProjectilLayer));
        {
            m_time += Time.deltaTime;
            if (m_time >= spawnInterwal)
            {
                m_time = 0f;
                GameObject go = Instantiate(m_projectilePrefab, FrontBarrel.transform.position, FrontBarrel.transform.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddForce(FrontBarrel.transform.up * m_BulletVelocity, ForceMode.Force);
                
            }

        }
    }
}
