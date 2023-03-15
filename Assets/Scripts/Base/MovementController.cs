using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    protected float speed;

    protected void Moving(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
