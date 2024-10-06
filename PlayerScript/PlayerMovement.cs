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
        Move();   
    }

    void Move(){

    }
}
