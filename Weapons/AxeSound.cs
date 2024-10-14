using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AxeNoise(){
        _audioSource.clip= _audioClip[Random.Range( 0 , _audioClip.Length)];
        _audioSource.Play();
    }
}
