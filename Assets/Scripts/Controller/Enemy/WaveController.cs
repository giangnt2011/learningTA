using DesignPattern;
using Common;
using System.Collections.Generic;
using UnityEngine;
using Controller.Player;

namespace Controller.Enemy
{
    [System.Serializable]

    public class WaveInfo
    {
        public float EnemyNumber;
        public int currentLevel;
    }
    public class WaveController : MonoBehaviour
    {
        public WaveInfo[] waveInfos;
        public WaveInfo _waveInfo;
        [SerializeField]private List<EnemyController> listEnemy = new List<EnemyController>();
        public int currentWave = 0;

        private void Awake()
        {
            Observer.Instance.AddObserver(GameKey.ENEMY_DIE, OnEnemyDie);
        }
        public void start()
        {
            _waveInfo = waveInfos[currentWave];

            InitiateEnemies();
        }
        void InitiateEnemies()
        {
            for(int i=0; i < _waveInfo.EnemyNumber; i++)
            {
                EnemyController enemy = Creator.Instance.CreateEnemy(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10)));
                enemy.levelEnemy = _waveInfo.currentLevel;
                if(enemy != null)
                {
                    listEnemy.Add(enemy);
                }
            }
        }

        void OnEnemyDie(object data)
        {
            EnemyController enemy = (EnemyController)data;
            listEnemy.Remove(enemy);
            if(listEnemy.Count == 0)
            {
                currentWave ++;
                if (currentWave > waveInfos.Length - 1) 
                {
                    Debug.Log("You Win");
                    Observer.Instance.Notify(GameKey.NEXT_STAGE, this);
                    return;
                }
                _waveInfo = waveInfos[currentWave];
                _waveInfo.currentLevel = currentWave+1;
                InitiateEnemies();
            }

        }

        private void OnDestroy()
        {
            Observer.Instance.RemoveObserver(GameKey.ENEMY_DIE, OnEnemyDie);
        }

    }
}
