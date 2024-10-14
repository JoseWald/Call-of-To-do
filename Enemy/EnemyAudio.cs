using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _screamClip , _dieClip;

    [SerializeField]
    private AudioClip[] _attackClip;
   
    void Awake(){
        _audioSource = GetComponent<AudioSource>();

    }
    
    public void PlayScreamSound(){
        _audioSource.clip = _screamClip;
        _audioSource.Play();
    }

    public void PlayAttackSound(){
        _audioSource.clip =_attackClip[Random.Range(0 , _attackClip.Length)] ;
        _audioSource.Play();
    }

    public void PlayDeadSound(){
        _audioSource.clip = _dieClip;
        _audioSource.Play();
    }
}
