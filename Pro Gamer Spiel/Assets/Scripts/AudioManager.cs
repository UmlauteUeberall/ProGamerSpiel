using UnityEngine;

public class AudioManager
{
    private static GameObject m_ambient;
    private static GameObject m_ambientSceneObject;
    private static GameObject m_gunShot;
    private static GameObject m_laserShot;
    private static GameObject m_laserShotSceneObject;
    private static Camera m_mainCamera;

    //set the audio files and the main camera
    //instantiate the ambient sound object
	static AudioManager()
    {
        m_ambient = Resources.Load<GameObject>("ambient");
        m_gunShot = Resources.Load<GameObject>("gunShot");
        m_laserShot = Resources.Load<GameObject>("laserShot");
        m_mainCamera = Camera.main;
	}

    /// <summary>
    /// Play the ambient sound
    /// at the Audio Listener position
    /// </summary>
    public static void PlayAmbient()
    {
        m_ambientSceneObject =
            (GameObject) GameObject.Instantiate(m_ambient,
            m_mainCamera.transform.position,
            m_mainCamera.transform.rotation);
    }

    /// <summary>
    /// stops playing the ambient sound
    /// </summary>
    public static void StopAmbient()
    {
        if(m_ambientSceneObject != null)
        {
            GameObject.Destroy(m_ambientSceneObject);
        }
    }

    /// <summary>
    /// Play the gun shot sound
    /// at the Audio Listener position
    /// </summary>
    public static void PlayGunShot()
    {
        GameObject.Instantiate(m_gunShot,
            m_mainCamera.transform.position,
            m_mainCamera.transform.rotation);
    }

    /// <summary>
    /// Play the gun shot sound
    /// at the Vector3 position
    /// </summary>
    /// <param name="_position">Vector3 position</param>
    public static void PlayGunShot(Vector3 _position)
    {
        GameObject.Instantiate(m_gunShot, _position,
            Quaternion.identity);
    }

    /// <summary>
    /// Play the laser shot sound
    /// at the Audio Listener position
    /// </summary>
    public static void PlayLaserShot()
    {
        m_laserShotSceneObject = 
            (GameObject)GameObject.Instantiate(m_laserShot,
            m_mainCamera.transform.position,
            m_mainCamera.transform.rotation);
    }

    /// <summary>
    /// Play the laser shot sound
    /// at the Vector3 position
    /// </summary>
    /// <param name="_position">Vector3 position</param>
    public static void PlaylaserShot(Vector3 _position)
    {
        m_laserShotSceneObject = 
            (GameObject)GameObject.Instantiate(m_laserShot,
            _position, Quaternion.identity);
    }

    /// <summary>
    /// stops playing the laser shot sound
    /// </summary>
    public static void StopLaserShot()
    {
        if (m_laserShotSceneObject != null)
        {
            GameObject.Destroy(m_laserShotSceneObject);
        }
    }
}
