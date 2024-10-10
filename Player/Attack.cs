using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private WeaponManager _weaponManager;

    public float fireRate;

    private float _nextTimetoFire;

    public float damage=20f;

    void Awake(){
        _weaponManager=GetComponent<WeaponManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot(){

        if(_weaponManager.GetSelectedWeapon().fireType==WeaponFireType.MULTIPLE){

            if(Input.GetMouseButton(0) && Time.time>_nextTimetoFire ){
                _nextTimetoFire= Time.time + 1f/fireRate;

                _weaponManager.GetSelectedWeapon().ShootAnimation();            
            }

        }else
        {
            if(Input.GetMouseButton(0)){

                if(_weaponManager.GetSelectedWeapon().tag =="AXE_TAG"){
                     _weaponManager.GetSelectedWeapon().ShootAnimation(); 
                }

                 if(_weaponManager.GetSelectedWeapon().bulletType ==WeaponBulletType.BULLET){
                     _weaponManager.GetSelectedWeapon().ShootAnimation(); 
                     
                    //BulletFired();
                }

            }
        }
    }
}
