using UnityEngine;

namespace Controller.Player
{
    public class CameraController : MonoBehaviour
    {
        void Update()
        {
            Vector3 playerPosion = Player.Instance.transform.position;
            transform.position = playerPosion + Vector3.back * 10;
        }
    }
}
