using Common;
using UnityEngine;

namespace Controller.Player
{
    public class PlayerController : TankController
    {
        float v;
        float h;
        Vector2 mousePoint;
        Vector3 mousePointWorld;
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

        protected override void TankDamage()
        {
            throw new System.NotImplementedException();
        }

        public override void OnHit(float damage)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Player : SingletonMonobehaviour<PlayerController>
    {
    
    }
}