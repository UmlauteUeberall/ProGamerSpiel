using UnityEngine;
using System.Collections;

public class PlayerCamController : MonoBehaviour {

    public float m_Rotationsspeed = 5f;

    private Camera m_Camera;

  
	void Start ()
    {
        // rotY = Input.GetAxis("Mouse Y");
        // rotX = Input.GetAxis("Mouse X");

        m_Camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Mouselook();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Mouselook()
    {
        Vector2 rot = new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        rot *= Time.deltaTime * m_Rotationsspeed;
        transform.Rotate(Vector3.up, rot.y);
        m_Camera.transform.Rotate(Vector3.right, rot.x);


    }
}
