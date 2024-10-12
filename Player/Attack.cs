using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private WeaponManager _weaponManager;

    public float fireRate;

    private float _nextTimetoFire;

    public float damage=20f;

    private Animator _revolverZooming;

    private bool _zoomed;

    private Camera _mainCam;

    private GameObject _crosshair;

    void Awake(){
        _weaponManager=GetComponent<WeaponManager>();
        _revolverZooming = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        _crosshair =GameObject.FindWithTag(Tags.CROSSHAIR);

        _mainCam=Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
        ZoomInOut();
    }

    void WeaponShoot(){

        if(_weaponManager.GetSelectedWeapon().fireType==WeaponFireType.MULTIPLE){

            if(Input.GetMouseButton(0) && Time.time>_nextTimetoFire/1.5 ){
                _nextTimetoFire= Time.time + 1f/fireRate;

                _weaponManager.GetSelectedWeapon().ShootAnimation(); 
                BulletFired();           
            }

        }else
        {
            if(Input.GetMouseButton(0)){

                if(_weaponManager.GetSelectedWeapon().tag =="AXE_TAG"){
                     _weaponManager.GetSelectedWeapon().ShootAnimation(); 
                }

                 if(_weaponManager.GetSelectedWeapon().bulletType ==WeaponBulletType.BULLET){
                     _weaponManager.GetSelectedWeapon().ShootAnimation(); 
                     
                    BulletFired();
                }

            }
        }
    }//WeaponShoot()

    void ZoomInOut(){
        if(_weaponManager.GetSelectedWeapon().weaponAim==WeaponAim.AIM){
            if(Input.GetMouseButtonDown(1)){
                _revolverZooming.Play(AnimationTags.ZOOM_IN_ANIM);
                _crosshair.SetActive(false);
            }

            if(Input.GetMouseButtonUp(1)){
                _revolverZooming.Play(AnimationTags.ZOOM_OUT_ANIM);
                _crosshair.SetActive(true);
            }
        }

    
    }//ZoomInOut()

    void BulletFired() {

           
           RaycastHit hit;
           
            if(Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out hit , Mathf.Infinity)) {
                 Debug.Log(hit.collider.gameObject.name);
                 Debug.DrawRay(_mainCam.transform.position , _mainCam.transform.forward ,Color.yellow);
                if(hit.collider.gameObject.name == "Cannibal") {
                    Debug.Log("Enemy attacked");
                    hit.transform.GetComponent<Health>().GetHurt(damage);
                }

            }

    } // bullet fired
}
