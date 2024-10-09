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
    public WeaponAim _weaponAim;

    [SerializeField]
    private GameObject _muzzleFlash;

    [SerializeField]
    private AudioSource _shootSound , _reloadSound;

    private WeaponFireType _fireType;

    private WeaponBulletType _bulletType;

    public GameObject attackPoint;

    void Awake(){
        _anim= GetComponent<Animator>();
    }
 
    public  void ShootAnimation(){
        _anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }
}
