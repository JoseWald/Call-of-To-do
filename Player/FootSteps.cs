using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private AudioSource _footStepSound;

    [SerializeField]
    private AudioClip[]  _footStepClip;

    private CharacterController _characterController; 

    [HideInInspector]
    public float volumeMAX , volumeMIN ;

    private float _accumulatedDistance ;

    [HideInInspector]
    public float stepDistance;
  
    void Awake(){
        _footStepSound = GetComponent<AudioSource>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ShouldPlayFootStepSound();
    }

    void ShouldPlayFootStepSound(){
        if(!_characterController.isGrounded){
            return;
        }

        if(_characterController.velocity.sqrMagnitude > 0){
            _accumulatedDistance +=Time.deltaTime;

            if(_accumulatedDistance > stepDistance){
                _footStepSound.volume = Random.Range(volumeMIN , volumeMAX);
                _footStepSound.clip = _footStepClip[Random.Range(0,_footStepClip.Length)];
                _footStepSound.play(); 
                _accumulatedDistance =0f;
            }

        }else
        {
            _accumulatedDistance;
        }
    }
}
