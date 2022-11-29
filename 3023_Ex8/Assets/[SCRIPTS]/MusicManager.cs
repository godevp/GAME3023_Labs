using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum TrackID
    {
        OutOfCollision,
        InsideOfCollision
    }
    public List<AudioClip> musicTracks;


    [SerializeField] AudioSource aSource1;
    [SerializeField] AudioSource aSource2;
    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<MusicManager>();
            }    
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
        MusicManager original = Instance;

        MusicManager[] managerClones = FindObjectsOfType<MusicManager>();
        foreach(MusicManager manager in managerClones)
        {
            if(manager != original)
            {
                Destroy(manager.gameObject);
            }
        }
        musicTracks.Add(aSource1.clip);
        musicTracks.Add(aSource2.clip);
    }

    public void PlayTrack(TrackID trackID)
    {
        aSource1.Stop();
        aSource2.Stop();

        aSource1.clip = musicTracks[(int)trackID];
        aSource1.volume = 1;
        aSource1.Play();
    }
    public void CrossFadeTo(TrackID ToTrackID,float transitionDuration)
    {
        AudioSource oldTrack = aSource1;
        AudioSource newTrack = aSource2;



        if (aSource1.isPlaying)
        {
            oldTrack = aSource1;
            newTrack = aSource2;
        }
        if(aSource2.isPlaying)
        {
            oldTrack = aSource2;
            newTrack = aSource1;
        }
        newTrack.clip = musicTracks[(int)ToTrackID];
        newTrack.Play();

        StartCoroutine(CrossFadeCrouratine(oldTrack, newTrack, transitionDuration));
    }

    private IEnumerator CrossFadeCrouratine(AudioSource oldTrack, AudioSource newTrack, float transitionDuration = 1.5f)
    {
        float time = 0.0f;
        while(time < transitionDuration)
        {
            float tValue = Mathf.Min(time / transitionDuration, 1.0f);
            newTrack.volume = tValue;
            oldTrack.volume = 1 - tValue;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        oldTrack.Stop();
        oldTrack.volume = 1;
    }
}
