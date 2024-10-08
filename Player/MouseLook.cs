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
    private float _smoothAngle=10f;

      [SerializeField]
    private float _rollAngle=0.1f;

    
    [SerializeField]
    private float _rollSpeed=5f;

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
        //lock the cursor to the center of the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlock();
        if(Cursor.lockState == CursorLockMode.Locked){
            LookAround();
        }
    }

    //to lock and unlock the cursor
    //in won't work in our unity editor
    void LockAndUnlock(){
        if(Input.GetKeyDown(KeyCode.Escape)){

            if(Cursor.lockState == CursorLockMode.Locked){
                // Debug.Log("Unlocked");
                 Cursor.lockState = CursorLockMode.None;
            }else
            {
                // Debug.Log("Locked");
                 Cursor.lockState = CursorLockMode.Locked;
                 Cursor.visible=false;
            }

        }
    }

    void LookAround(){
        _currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MOUSE_Y),Input.GetAxis(MouseAxis.MOUSE_X));
        _lookAngle.x +=_currentMouseLook.x * _sensivity * (_invert ? 1f : -1f);
        _lookAngle.y +=_currentMouseLook.y * _sensivity;

        _lookAngle.x = Mathf.Clamp(_lookAngle.x , _defaultLookLimits.x , _defaultLookLimits.y);

        //causing an effect of dizziness if the rollAngle's value si too high
        _currentRollAngle = Mathf.Lerp(_currentRollAngle ,
                                         Input.GetAxisRaw(MouseAxis.MOUSE_X)*_rollAngle ,
                                         _rollSpeed*Time.deltaTime );

        _lookRoot.localRotation = Quaternion.Euler(_lookAngle.x , 0f , _currentRollAngle);
        _playerRoot.localRotation = Quaternion.Euler( 0f , _lookAngle.y , 0f);       
    }
}
