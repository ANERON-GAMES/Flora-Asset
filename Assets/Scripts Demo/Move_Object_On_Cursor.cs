using UnityEngine;

public class Move_Object_On_Cursor : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 1f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
