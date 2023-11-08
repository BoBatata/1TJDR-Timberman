using System;
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
        GameManager.instance.inputManager.OnHit += HitHandler;
    }

    private void HitHandler(Vector2 touchPos)
    {
        CheckHitPositon(touchPos);
        PlayHitAnimation();
        PlayHitSFX();
        TimberHit();
    }

    private void CheckHitPositon(Vector2 touchPos)
    {
        float screenSize = Camera.main.pixelWidth;
        if (touchPos.x < (screenSize / 2))
        {
            transform.parent.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (touchPos.x > (screenSize / 2))
        {
            transform.parent.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
    private void PlayHitSFX()
    {
        GameManager.instance.PlaySFXAudioByType(SFXAudioType.Hit);
    }

    private void PlayHitAnimation()
    {
        animator.SetTrigger("pHit");
    }


    private void TimberHit()
    {
        GameManager.instance.OnTrunkHit();
        animator.SetTrigger("pHit");
        Debug.Log("HIT!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TrunkBase>()) 
        {
            GameManager.instance.GameOver();        
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.inputManager.OnHit -= HitHandler;
    }
}
