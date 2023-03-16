using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using Controller.Interface;
using Controller.Player;
using UnityEngine;

public class BulletController : MovementController
{
    public float damage;
    int count = 0;

    private void Update()
    {
        Moving(transform.up);
        count++;
        if(count > 200)
        {
            Destroy(gameObject);
            Creator.Instance.CreateExplosion(transform);
        }
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, 0.2f);
        
        if(hit.transform != null)
        {
            IHit ihit = hit.transform.GetComponent<IHit>();
            if(ihit != null)
            {
                ihit.OnHit(damage);
                Creator.Instance.CreateExplosion(transform);
                Destroy(gameObject);
            }
        }
    }
}
