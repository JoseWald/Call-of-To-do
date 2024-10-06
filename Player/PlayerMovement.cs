using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController  _characterController;
    private Vector3 _moveDir;//move direction
    public float speed;
    public float gravity;
    public float jumpForce;
    private float _verticalVelocity;

    void Awake(){
        _characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();   
    }

    void Moving(){
        _moveDir = new Vector3(Input.GetAxis(Axis.HORIZONTAL),0f,Input.GetAxis(Axis.VERTICAL));
        _moveDir = transform.TransformDirection(_moveDir);
        _moveDir *=speed*Time.deltaTime;

        ApplyGravity();

        _characterController.Move(_moveDir);
    }

    void ApplyGravity(){
        _verticalVelocity -=gravity*Time.deltaTime;
        Jump();
        _moveDir.y=_verticalVelocity*Time.deltaTime;
    }

    void Jump(){
        if(_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)){
            _verticalVelocity=jumpForce;
        }
    }
}
