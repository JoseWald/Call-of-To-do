using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform _playerRoot , _lookRoot;

    [SerializeField]
    private bool _invert;

    // to lock and unlock the mouse cursor because we don't need to see the mouse cursor in a FPS game
    [SerializeField]
    private bool _canUnlocked=true;

    [SerializeField]
    private float _sensivity;

    [SerializeField]
    private int _smoothSteps=10;

    [SerializeField]
    private float _smoothWeight=0.4f;

    [SerializeField]
    private float _soothAngle=10f;

    [SerializeField]
    private Vector2 _defaultLookLimits= new Vector2(-70f , 80f );

    private Vector2 _lookAngle;

    private Vector2 _currentMouseLook;

    private Vector2 _smoothMouse;

    private float _currentRollAngle;

    private int _lastLookFrame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
