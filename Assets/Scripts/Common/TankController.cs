using Base;
using Controller.Interface;
using Controller.Player;
using UnityEngine;

namespace Common
{
    [System.Serializable]

    public class TankInfo
    {
        public float speed;
        public float MaxHP;
        public float damage;
    }

    public abstract class TankController : MovementController, IHit
    {
        [SerializeField] protected TankInfo[] infos;
        [SerializeField] protected Transform gun;
        [SerializeField] protected Transform tranShoot;
        TankInfo _tankInfo;

        protected void Shoot()
        {
            BulletController bullet = Creator.Instance.CreateBullet(tranShoot);
            bullet.damage = _tankInfo.damage;
        }

        protected void RotateGun(Vector3 direction)
        {
            gun.up= direction;
        }
        protected abstract void TankDamage();
        public abstract void OnHit(float damage);
    }
}