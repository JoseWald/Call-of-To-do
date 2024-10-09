using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndCrouch : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public float runSpeed=10f;
    public float moveSpeed=5f;
    public float crouchSpeed=2f;

    private Transform _lookRoot;
    private float _standHeight = 1.6f;
    private float _crouchHeight=1f;

    private FootSteps _playerFootSteps;

    private float _sprintVolume=1f;

    private float _crouchVolume=0.1f;

    private float _walkVolumeMIN=0.2f , _walkVolumeMAX=0.6f;

    private bool _isCrouching=false;

    private float _walkStepDistance=0.4f;

    private float _sprintStepDistance=0.25f;

    private float _crouchDistance=0.5f;
    
    
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _lookRoot=transform.GetChild(0);
        _playerFootSteps=GetComponentInChildren<FootSteps>(); 
    }

    void Start(){
        _playerFootSteps.volumeMIN=_walkVolumeMIN;
        _playerFootSteps.volumeMAX=_walkVolumeMAX;
        _playerFootSteps.stepDistance=_walkStepDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Crouch();
    }

    void Run(){
       if( Input.GetKeyDown(KeyCode.LeftShift) ){
            _lookRoot.localPosition = new Vector3(0f,_standHeight,0f);
           _playerMovement.speed=runSpeed;

           _isCrouching=false;

           _playerFootSteps.stepDistance=_sprintStepDistance;
           _playerFootSteps.volumeMIN = _sprintVolume;
           _playerFootSteps.volumeMAX = _sprintVolume;
       }

       if(Input.GetKeyUp(KeyCode.LeftShift) && !_isCrouching){
           _playerMovement.speed = moveSpeed;
         
           _playerFootSteps.volumeMIN=_walkVolumeMIN;
           _playerFootSteps.volumeMAX=_walkVolumeMAX;
           _playerFootSteps.stepDistance=_walkStepDistance;
       }
    }

    void Crouch(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(_isCrouching){
                _lookRoot.localPosition = new Vector3(0f,_standHeight,0f);
                _playerMovement.speed =moveSpeed;

                _isCrouching=false;

                _playerFootSteps.stepDistance=_crouchDistance;
                _playerFootSteps.volumeMIN=_crouchVolume;
                _playerFootSteps.volumeMAX=_crouchVolume;
            }else
            {
                _lookRoot.localPosition = new Vector3(0f,_crouchHeight,0f);
                _playerMovement.speed =crouchSpeed;

                _isCrouching=true;

                _playerFootSteps.volumeMIN=_walkVolumeMIN;
                _playerFootSteps.volumeMAX=_walkVolumeMAX;
                _playerFootSteps.stepDistance=_walkStepDistance;
            }
        }
    }
}
