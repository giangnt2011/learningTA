using Base;
using UnityEngine;

namespace Common
{
    public class HPController : ProcessingController
    {
        public delegate void Die();
        public Die die;

        public void InitValue(float maxValue)
        {
            InitiateValue(maxValue);
        }

        public void TakeDamge(float damage)
        {
            ChangeValue(currentValue - damage);
            if(currentValue == 0 && die != null) { die(); }
        }
    }
}
