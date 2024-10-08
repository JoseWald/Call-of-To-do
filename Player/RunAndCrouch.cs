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

    private boll _isCrouching=false;
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
