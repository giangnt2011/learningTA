using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class TankInfo
{
    float speed;
    float MaxHP;
    float damage;
}

public abstract class TankController : MovementController, IHit
{
    [SerializeField] protected TankInfo[] infos;
    [SerializeField] protected Transform gunTrans;
    TankInfo tankInfo;

    protected void Shoot()
    {

    }

    protected abstract void TankDamage();
    public abstract void OnHit(float damage);
}
