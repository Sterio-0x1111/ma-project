using UnityEngine;

public class CameraFixZwei : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0f, 20f, 0f);
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}