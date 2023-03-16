using Common;
using Controller.Enemy;
using DesignPattern;
using UnityEngine;

namespace Controller.Player
{
    public class PlayerController : TankController
    {
        float v;
        float h;
        Vector2 mousePoint;
        Vector3 mousePointWorld;

        protected override void Awake()
        {
            base.Awake();
            levelController.SetLevel(1);
            Observer.Instance.AddObserver(GameKey.ENEMY_DIE, OnEnemyDie);
        }

        private void Update()
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            Vector3 direction = new Vector3(h,v);
            Moving(direction);

            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePointWorld = new Vector3(mousePoint.x, mousePoint.y) - gun.position;
            RotateGun(mousePointWorld);
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        protected override void TankDestroy()
        {
            Debug.Log("You Lose");
        }

        public override void OnHit(float damage)
        {
            hpController.TakeDamge(damage);
        }

        void OnEnemyDie(object data)
        {
            EnemyController enemy = (EnemyController)data;
            levelController.UpdateEXP(enemy.currentLevel*20);
        }
    }

    public class Player : SingletonMonobehaviour<PlayerController>
    {
    
    }
}