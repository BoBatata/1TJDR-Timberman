using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PlayerBehavior : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.instance.inputManager.OnHit += TimberHit;
    }

    private void TimberHit()
    {
        //ToDo
        animator.SetTrigger("pHit");
        GameManager.instance.PlaySFXAudioByType(SFXAudioType.Hit);  
        Debug.Log("HIT!");
    }

    private void OnDestroy()
    {
        GameManager.instance.inputManager.OnHit -= TimberHit;
    }
}
