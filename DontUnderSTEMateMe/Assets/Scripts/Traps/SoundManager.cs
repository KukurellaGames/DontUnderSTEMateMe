using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSourc;

    [SerializeField]
    private AudioClip[] m_footStepSounds;

    // Start is called before the first frame update
    void Start()
    {
        _audioSourc = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySteps(int n)
    {
        if (n == 0) _audioSourc.PlayOneShot(m_footStepSounds[n]);
        if (n == 1) _audioSourc.PlayOneShot(m_footStepSounds[n]);
    }
}
