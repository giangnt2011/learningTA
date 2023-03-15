using UnityEngine;

namespace Base
{
    public class MovementController : MonoBehaviour
    {
        protected float speed;

        protected void Moving(Vector3 direction)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
