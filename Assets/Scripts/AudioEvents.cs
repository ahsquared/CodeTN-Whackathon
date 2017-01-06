﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour {

    void Awake()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayEvent(string eventName)
    {
        AkSoundEngine.PostEvent(eventName, gameObject, (uint)AkCallbackType.AK_MusicSyncUserCue, MusicCallback, this);
    }

    private void MusicCallback(object in_cookie, AkCallbackType in_type, object in_info)

    {
        Debug.Log(in_cookie);
        Debug.Log(in_type);
        Debug.Log(in_info);

        if (in_type == AkCallbackType.AK_MusicSyncUserCue)

        {
            AkCallbackManager.AkMusicSyncCallbackInfo musicInfo = (AkCallbackManager.AkMusicSyncCallbackInfo) in_info;
            Debug.Log("cue time: " + musicInfo.segmentInfo.iCurrentPosition + " , duration: " + musicInfo.segmentInfo.iActiveDuration);
            int cueTime = musicInfo.segmentInfo.iCurrentPosition;
            int duration = musicInfo.segmentInfo.iActiveDuration;
            if (10000 < cueTime && cueTime < 21000)
            {
                iTween.ValueTo(gameObject, iTween.Hash(
                    "from", 0f,
                    "to", 100f,
                    "time", 8f,
                    "onupdatetarget", gameObject,
                    "onupdate", "tweenTimeStretch",
                    "easetype", iTween.EaseType.easeOutQuad
                    )
                );
            }
        }

    }
    void tweenTimeStretch(int newValue)
    {
        Debug.Log("time stretch: " + newValue);
        SetRTPCValue("GamePercentage", (float)newValue);
    }

    public void StopEvent(string eventName, float fadeOut)
    {
        var eventId = AkSoundEngine.GetIDFromString(eventName);
        AkSoundEngine.ExecuteActionOnEvent(eventId, AkActionOnEventType.AkActionOnEventType_Stop, gameObject,
            (int) (fadeOut * 1000), AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    public void SetRTPCValue(string rtpcName, float value)
    {
        AkSoundEngine.SetRTPCValue(rtpcName, value);
    }
}
