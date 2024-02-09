using UnityEngine;

public class Earth : MonoBehaviour
{
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 30f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kugel"))
        {
            gameObject.SetActive(false);
            count = 1 + count;
        }
    }
}
