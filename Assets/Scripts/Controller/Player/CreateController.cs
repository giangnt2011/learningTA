using Controller.Enemy;
using UnityEngine;

namespace Controller.Player
{
    public class CreateController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPref;
        [SerializeField] private BulletController bulletPref;
        [SerializeField] private EnemyController enemyPref;

        public BulletController CreateBullet(Transform tranShoot)
        {
            return Instantiate(bulletPref, tranShoot.position, tranShoot.rotation);
        }

        public void CreateExplosion(Transform pos)
        {
            Instantiate(explosionPref, pos.position, pos.rotation);
        }

        public EnemyController CreateEnemy(Transform pos)
        {
            return Instantiate(enemyPref, pos.position, pos.rotation);
        }
    }

    public class Creator : SingletonMonobehaviour<CreateController>{}
}