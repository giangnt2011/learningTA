using DesignPattern;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Controller.Player;

namespace Controller.Enemy
{
    [System.Serializable]
    public class StageInfo
    {
        public WaveInfo[] WaveInfos;
    }
    public class StageController : MonoBehaviour
    {
        [SerializeField] private StageInfo[] stageInfos;
        private StageInfo _stageInfo;
        private int currentStage = 0;

        private void Awake()
        {
            Observer.Instance.AddObserver(GameKey.NEXT_STAGE, LoadNextStage);
            _stageInfo = stageInfos[currentStage];
            InitiateWave();
        }

        void InitiateWave()
        {
            Debug.Log("Your current Stage: " + currentStage);
            WaveController wave = Creator.Instance.CreateWave(transform.position);
            wave.waveInfos = _stageInfo.WaveInfos;
            wave.start();
        }

        void LoadNextStage(object data)
        {
            currentStage++;
            Debug.Log("Your current Stage: " + currentStage);
            WaveController wave = (WaveController)data;
            if (currentStage > stageInfos.Length - 1)
            {
                Debug.Log("Play All Stage");
                return;
            }
            _stageInfo = stageInfos[currentStage];
            wave.waveInfos = _stageInfo.WaveInfos;
            wave.currentWave = 0;
            wave.start();
        }

    }
}
