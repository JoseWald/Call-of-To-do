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

    private bool _isCrouching=false;
    
    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _lookRoot=transform.GetChild(0);
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
       }

       if(Input.GetKeyUp(KeyCode.LeftShift) && !_isCrouching){
           _playerMovement.speed = moveSpeed;
       }
    }

    void Crouch(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(_isCrouching){
                _lookRoot.localPosition = new Vector3(0f,_standHeight,0f);
                _playerMovement.speed =moveSpeed;

                _isCrouching=false;
            }else
            {
                  _lookRoot.localPosition = new Vector3(0f,_crouchHeight,0f);
                _playerMovement.speed =crouchSpeed;

                _isCrouching=true;
            }
        }
    }
}
