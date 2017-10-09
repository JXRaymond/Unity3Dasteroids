﻿using UnityEngine;
using System.Collections;

public class alienShoot : MonoBehaviour
{

    public Transform player;
    public float range = 50.0f;
    public float push = 20.0f;

    private bool onRange = false;

    public Rigidbody projectile;

    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {

        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * push, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }


    }

    void Update()
    {

        onRange = Vector3.Distance(transform.position, player.position) < range;
    }


}