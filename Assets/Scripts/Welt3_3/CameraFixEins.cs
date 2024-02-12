using UnityEngine;

public class CameraFixEins : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        transform.position = player.position + new Vector3(0f, 50f, -50f);
        transform.rotation = Quaternion.Euler(46f, 0f, 0f);
    }
}