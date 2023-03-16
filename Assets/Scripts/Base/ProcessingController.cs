using Common;
using UnityEngine;

namespace Base
{
    public class ProcessingController : MonoBehaviour
    {
        public float maxValue;
        public float currentValue;

        private float maxScale = 0.3f;

        private void Awake()
        {
            DisplayProcessing();
        }
        protected void InitiateValue(float maxValue)
        {
            this.currentValue = maxValue;
            DisplayProcessing();
            this.maxValue = maxValue;
        }
        protected void InitiateValue(float maxValue, float startValue)
        {
            this.currentValue = startValue;
            this.maxValue = maxValue;
            DisplayProcessing();
        }
        protected void ChangeValue(float currentValue)
        {
            this.currentValue = currentValue;
            if(this.currentValue > maxValue) { this.currentValue = maxValue; }
            if(this.currentValue < 0) { this.currentValue = 0; }
            DisplayProcessing();
        }
        private void DisplayProcessing()
        {
            if(maxValue == 0) { return; }
            transform.localScale = new Vector3(maxScale * currentValue / maxValue, transform.localScale.y);
        }

    }
}
