using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    private uint _bankId;
	// Use this for initialization
	protected void LoadBank ()
	{
	    AkSoundEngine.LoadBank("Main", AkSoundEngine.AK_DEFAULT_POOL_ID, out _bankId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayEvent(string eventName)
    {
        AkSoundEngine.PostEvent(AkSoundEngine.GetIDFromString("AcornHit"), gameObject);
    }
}
