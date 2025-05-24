using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suofang : MonoBehaviour
{
    private Touch oldTouch1;
    private Touch oldTouch2;

    void Update()
    {
        if (Input.touchCount <= 0) return;

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;
            transform.Rotate(Vector3.down * deltaPos.x, Space.World);
            transform.Rotate(Vector3.right * deltaPos.y, Space.World);
        }

        if (Input.touchCount >= 2)
        {
            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);

            if (newTouch2.phase == TouchPhase.Began)
            {
                oldTouch1 = newTouch1;
                oldTouch2 = newTouch2;
                return;
            }

            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
            float offset = newDistance - oldDistance;
            float scaleFactor = offset / 75f;

            Vector3 scale = transform.localScale + Vector3.one * scaleFactor;
            if (scale.x >= 0.5f && scale.x <= 2f)
                transform.localScale = scale;

            oldTouch1 = newTouch1;
            oldTouch2 = newTouch2;
        }
    }
}
