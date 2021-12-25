using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _anim;

    [SerializeField] private GameObject damageCollider;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _anim.SetTrigger(TagManager.ATTACKTRIGGERPARAMETR);
    }

    public void PlayDeath()
    {
        _anim.SetBool(TagManager.DEATHANIMATIONPARAMETR,true);
    }

    void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
    
    
}
