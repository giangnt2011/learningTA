using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class BulletController : MovementController
{
    public float damage;

    private void Update()
    {
        Moving(transform.up);
    }
}
