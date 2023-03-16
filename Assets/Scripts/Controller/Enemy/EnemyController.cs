using Common;
using DesignPattern;
using UnityEngine;

namespace Controller.Enemy
{
    public class EnemyController : TankController
    {
        float v;
        float h;
        Vector2 mousePoint;
        Vector3 mousePointWorld;

        public float damage;
        public int levelEnemy;


        protected override void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            levelController.SetLevel(levelEnemy);
        }
        private void Update()
        {
            //v = Input.GetAxis("Vertical");
            //h = Input.GetAxis("Horizontal");
            //Vector3 direction = new Vector3(h, v);
            //Moving(direction);

            //mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //mousePointWorld = new Vector3(mousePoint.x, mousePoint.y) - gun.position;
            //RotateGun(mousePointWorld);
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Shoot();
            //}
        }

        protected override void TankDestroy()
        {
            Observer.Instance.Notify(GameKey.ENEMY_DIE, this);
            Destroy(gameObject);
        }

        public override void OnHit(float damage)
        {
            //Debug.Log("enemycontroller: take damge");
            TakeDamage(damage);
        }
    }
}
