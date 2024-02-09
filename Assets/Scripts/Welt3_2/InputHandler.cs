using UnityEngine;

public class InputHandler : MonoBehaviour
{
    bool isTouched = false;

    [SerializeField]
    private Rigidbody rb;

    public float difficulty = 1f;

    void Start()
    {
        rb.mass = 0f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Überprüft, ob die Berührung auf dem Bildschirm innerhalb des GameObjects stattfindet
            if (touch.phase == TouchPhase.Began && IsTouchOnObject(touch.position))
            {
                isTouched = true;
                rb.mass = difficulty;
            }

            if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && isTouched)
            {
                isTouched = false;
                rb.mass = 0f;
            }
        }
    }

    bool IsTouchOnObject(Vector2 touchPosition)
    {
        // Berücksichtigt die Bildschirmauflösung und -orientierung, um die Touch-Koordinaten anzupassen
        Vector3 adjustedTouchPosition = new Vector3(touchPosition.x, touchPosition.y, Camera.main.nearClipPlane);
        Ray ray = Camera.main.ScreenPointToRay(adjustedTouchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
