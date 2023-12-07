using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name )
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    IEnumerator DisableSound(AudioSource audio)
    {
        while (audio.isPlaying)
            yield return new WaitForSeconds(0.5f);
        audio.gameObject.SetActive(false);
    }




}
