using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float xDelta;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            xDelta = Input.GetAxis("Mouse X");

            EventManager.CallOnDragEvent(xDelta);
        }
    }
}
