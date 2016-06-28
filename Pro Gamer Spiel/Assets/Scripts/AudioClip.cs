using UnityEngine;

public class AudioClip : MonoBehaviour
{
    private float m_audioLength;

    //set the length of the audio clip
	void Awake ()
    {
        m_audioLength = GetComponent<AudioSource>().clip.length;
	}
	
    //if the audio clip is played
    //the object will be destroyed
	void Update ()
    {
        m_audioLength -= 1 * Time.deltaTime;
	    if(m_audioLength <= 0)
        {
            Destroy(gameObject);
        }
	}
}
