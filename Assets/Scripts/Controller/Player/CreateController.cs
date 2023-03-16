using Controller.Enemy;
using UnityEngine;

namespace Controller.Player
{
    public class CreateController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPref;
        [SerializeField] private BulletController bulletPref;
        [SerializeField] private EnemyController enemyPref;
        [SerializeField] private WaveController wavePref;


        public BulletController CreateBullet(Transform tranShoot)
        {
            return Instantiate(bulletPref, tranShoot.position, tranShoot.rotation);
        }

        public void CreateExplosion(Transform pos)
        {
            Destroy(Instantiate(explosionPref, pos.position, pos.rotation), 0.5f);
        }

        public EnemyController CreateEnemy(Vector3 pos)
        {
            return Instantiate(enemyPref, pos, Quaternion.identity);
        }

        public WaveController CreateWave(Vector3 pos)
        {
            return Instantiate(wavePref, pos, Quaternion.identity);
        }
    }

    public class Creator : SingletonMonobehaviour<CreateController>{}
}