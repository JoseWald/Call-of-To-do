using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    private WeaponHandler[] _weapons;

    private int _currentWeaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        _currentWeaponIndex=0;
        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SelectWeapon(0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SelectWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            SelectWeapon(2);
        }
    }

    void SelectWeapon(int index){
        if(_currentWeaponIndex==index)
            return;
            
        _weapons[_currentWeaponIndex].gameObject.SetActive(false);
        _weapons[index].gameObject.SetActive(true);
        _currentWeaponIndex=index;
    }

    public WeaponHandler GetSelectedWeapon(){
        return _weapons[_currentWeaponIndex];
    }
}
