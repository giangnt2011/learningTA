 
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
        public float MaxEXP;
        public float damage;
    }

    public abstract class TankController : MovementController, IHit
    {
        //dkafka
        [SerializeField] protected Transform gun;
        [SerializeField] protected Transform tranShoot;
        [SerializeField] protected Transform tank;
        [SerializeField] protected HPController hpController;
        [SerializeField] protected LevelController levelController;
        public TankInfo _tankInfo;

        protected abstract TankVO tankVo { get; }
        public float currentLevel
        {
            get { return levelController.Level; }
        }

        protected virtual void Awake()
        {
            hpController.die = TankDestroy;
            levelController.onUpLevel = OnUpLevel;
        }

        protected override void Moving(Vector3 direction)
        {
            base.Moving(direction);
            tank.up = direction;
        }
        protected void Shoot()
        {
            BulletController bullet = Creator.Instance.CreateBullet(tranShoot);
            bullet.damage = _tankInfo.damage;
            bullet.speed= _tankInfo.speed*2;
        }

        protected void RotateGun(Vector3 direction)
        {
            gun.up= direction;
        }

        public void TakeDamage(float damage)
        {
            hpController.TakeDamge(damage);
        }
        public void OnUpLevel(int level)
        {
            _tankInfo = tankVo.GetTankInfo(level);
            // if (level > infos.Length) { return; }
            // _tankInfo = infos[level-1];
            speed = _tankInfo.speed;
            hpController.InitValue(_tankInfo.MaxHP);
            levelController.InitMaxEXP(_tankInfo.MaxEXP);
        }
        protected abstract void TankDestroy();
        public abstract void OnHit(float damage);
    }
}