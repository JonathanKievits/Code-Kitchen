using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// You cant serialize a dictionary. 
    /// So it has to be done with 2 arrays
    /// </summary>
    [SerializeField]
    private string[] _names;
    [SerializeField]
    private AudioClip[] _sounds;

    public Dictionary<string, AudioClip> SoundDic;

    void Start()
    {
        SoundDic = new Dictionary<string, AudioClip>();

        //Adds sound to dictionary from arrays
        for (int i = 0; i < _names.Length; i++)
        {
            SoundDic[_names[i]] = _sounds[i];
        }
    }

    //Plays sound in dictionary with given name
    public void PlaySound(string name)
    {
        //Makes sure the given name exists
        for (int i = 0; i < _names.Length; i++)
        {
            if (name == _names[i])
            {
                AudioSource newAudio = gameObject.AddComponent<AudioSource>();
                newAudio.loop = false;
                newAudio.playOnAwake = false;
                newAudio.clip = SoundDic[name];
                newAudio.Play();
                Destroy(newAudio,newAudio.clip.length);
            }
            else
            {
                Debug.LogWarning("Name does not exist");
            }
        }       
    }
}
