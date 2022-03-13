using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader_BigBoss : Invader
{
    public GameObject missilePrefab;
    public int rotation;
    private void Awake()
    {
        SetAnimation();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
        InvokeRepeating("Attack", 10, Random.Range(3, 5)); //время начала когда приблизится к игроку
    }

    void Attack()
    {
       var bullet =  Instantiate(missilePrefab, transform.position, Quaternion.identity);
        bullet.transform.rotation *= Quaternion.Euler(0, 0, rotation);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
