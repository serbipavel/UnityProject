using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    
    public SoundArray[] randSounds;

    private AudioSource audioScr => GetComponent<AudioSource>();

    public void PlaySound(int index, float volume = 1f, bool random=false, bool destroyed=false, float p1=0.85f, float p2=1.2f)
    {
        AudioClip clip = random ? randSounds[index].soundArray[Random.Range(0, randSounds[index].soundArray.Length)] : randSounds[index].soundArray[0];
        audioScr.pitch = Random.Range(p1,p2);
        if (destroyed)
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        else
            audioScr.PlayOneShot(clip,volume);
    }

    [System.Serializable]
    public class SoundArray
    {
        public AudioClip[] soundArray;
    }
}
