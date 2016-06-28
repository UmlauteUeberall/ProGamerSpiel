using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour 
{
    public int m_PivotxMin;
    public int m_PivotxMax;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        Rotation();
	}
    void Rotation()
    {
        transform.Rotate(new Vector3(1, 5, 3) * (Time.deltaTime));
    }
}
