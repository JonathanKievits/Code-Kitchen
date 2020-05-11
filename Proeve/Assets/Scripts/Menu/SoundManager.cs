using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audio;

    //You cant serialize a dictionary. 
    //So it has to be done with 2 arrays
    [SerializeField]
    private string[] _names;
    [SerializeField]
    private AudioClip[] _sounds;

    public Dictionary<string, AudioClip> SoundDic;

    void Start()
    {
        //Makes sure there is an audio source
        if (_audio == null)
        {
            _audio = GetComponent<AudioSource>();
        }

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
                _audio.clip = SoundDic[name];
            }
            else
            {
                Debug.LogWarning("Name does not exist");
            }
        }       

        _audio.Play();
    }
}
