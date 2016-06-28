using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    //private LevelManager m_levelManager;

    public static LevelManager Get { get; private set; }


	// Use this for initialization
	void Awake () 
	{
        if (Get != null)
        {
            Debug.LogWarning("LevelManager exisitiert bereits, lösche diesen");
            Destroy(gameObject);
            return;
        }

        Get = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
