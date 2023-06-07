using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public void PlayAudio(AudioClip audio, float volume = 1f, bool loop = false)
    {
        AudioSource[] audioSources = GetComponents<AudioSource>(); // Get all AudioSource components attached to the GameObject
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying) // Check if the AudioSource is not currently playing any audio
            {
                audioSources[i].clip = audio; // Assign the AudioClip to the AudioSource
                if (volume != 1f)
                {
                    audioSources[i].volume = volume; // Set the volume of the AudioSource if it's not the default value
                }
                audioSources[i].Play(); // Play the audio
                break;
            }

            if (i == audioSources.Length - 1) // If no available AudioSource is found
            {
                AudioSource newAudioSource = gameObject.AddComponent<AudioSource>(); // Create a new AudioSource component
                newAudioSource.loop = loop; // Set the loop property
                newAudioSource.playOnAwake = false; // Disable playOnAwake
                newAudioSource.clip = audio; // Assign the AudioClip to the new AudioSource

                if (volume != 1f)
                {
                    newAudioSource.volume = volume; // Set the volume of the new AudioSource if it's not the default value
                }
                newAudioSource.Play(); // Play the audio
                break;
            }
        }
    }
}
