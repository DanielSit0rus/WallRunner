using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlaySound(AudioClip clip, float volume = 1.0f) // takes in the audip clip that will be played and the volume level
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip; // set the audio clip that the audio source will play
        audioSource.volume = volume;
        audioSource.Play(); // start playing the clip

        Destroy(gameObject, clip.length); // the object will be destroyed when the clip has finished playing
    }
}
