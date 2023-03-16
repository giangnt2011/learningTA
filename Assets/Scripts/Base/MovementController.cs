using UnityEngine;

namespace Base
{
    public class MovementController : MonoBehaviour
    {
        public float speed;

        protected virtual void Moving(Vector3 direction)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
