using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeAttack : MonoBehaviour
{
    public float damage;

    public float radius=1f;

    public LayerMask layerMask;


    // Update is called once per frame
    void Update()
    {
        Collider[] hits=Physics.OverlapSphere(transform.position , radius , layerMask);

        if(hits.Length > 0){
           // Debug.Log("We touched the"+ hits[0].gameObject.tag);
           hits[0].gameObject.GetComponent<Health>().GetHurt(damage);
            gameObject.SetActive(false);
        }
    }
}
