using Base;
using TMPro;
using UnityEngine;

namespace Common
{
    public class LevelController : ProcessingController
    {
        public delegate void UpLevel(int level);
        public UpLevel onUpLevel;
        [SerializeField] private TextMeshPro txt_level;
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; txt_level.text = "Lv." + level; }
        }

        public void InitMaxEXP(float maxEXP)
        {
            InitiateValue(maxEXP);
        }

        public void UpdateEXP(float exp)
        {
            ChangeValue(currentValue + exp);
            if(currentValue == maxValue && onUpLevel != null)
            {
                Level = Level+ 1;
                onUpLevel(Level);
                ChangeValue(0);
            }
        }

        public void SetLevel(int level)
        {
            
            Level = level;
            if(onUpLevel != null) { onUpLevel(Level); }
            ChangeValue(0);
        }

    }
}
