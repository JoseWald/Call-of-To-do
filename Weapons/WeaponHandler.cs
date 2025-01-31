using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim{
    NONE,
    AIM
}

public enum WeaponFireType{
    SINGLE,
    MULTIPLE
}

public enum WeaponBulletType{
    BULLET,
    NONE
}

public class WeaponHandler : MonoBehaviour
{

    private Animator _anim;
    public WeaponAim weaponAim;

    [SerializeField]
    private GameObject _muzzleFlash;

    [SerializeField]
    private AudioSource _shootSound , _reloadSound;

    
    public WeaponFireType fireType;


    public  WeaponBulletType bulletType;

    public GameObject attackPoint;

    void Awake(){
        _anim= GetComponent<Animator>();
    }
 
    public  void ShootAnimation(){
        _anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim){
        _anim.SetBool(AnimationTags.AIM_PARAMETER , canAim);
    }

    void TurnOnMuzzleFlash(){
        _muzzleFlash.SetActive(true);
    }

    void TurnOffMuzzleFlash(){
        _muzzleFlash.SetActive(false);
    }

    void PlayShootSound(){
        _shootSound.Play();
    }

    void PlayReloadSound(){
        _reloadSound.Play();
    }

    void TurnOnAttackPoint(){
        attackPoint.SetActive(true);
    }

     void TurnOffAttackPoint(){
         if(attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }
}
