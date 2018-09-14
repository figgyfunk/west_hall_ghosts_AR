using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetPlayAudio : MonoBehaviour,
                                            ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private bool foundOnce = false;
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (foundOnce)
            {
                GetComponent<AudioSource>().UnPause();
            }
            // Play audio when target is found
            else
            {
                GetComponent<AudioSource>().Play();
            }
            
        }
        else
        {
            // Stop audio when target is lost
            GetComponent<AudioSource>().Pause();
        }
    }
}

