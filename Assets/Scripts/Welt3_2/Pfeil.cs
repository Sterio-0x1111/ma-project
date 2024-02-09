using UnityEngine;

public class Pfeil : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position),
            2 * Time.deltaTime);
        }
    }
}
