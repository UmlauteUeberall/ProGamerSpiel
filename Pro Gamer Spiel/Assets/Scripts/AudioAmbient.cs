using UnityEngine;

public class AudioAmbient : MonoBehaviour
{
    private Camera m_mainCamera;

    //set the main camera
	void Awake ()
    {
        m_mainCamera = Camera.main;
	}
	
    //set the position to the main camera
	void Update ()
    {
        transform.position = m_mainCamera.transform.position;
	}
}
