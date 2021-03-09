using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SwipeType
{
    None = 0,
    Right,
    Left,
    Up,
    Down
}

public class PlayerInputController : MonoBehaviour
{
    Vector3 beginTouchPos = Vector3.zero;
    Vector2 swipeDelta = Vector2.zero;

    bool isDragging = false;

    float swipeThreshold = 50f;

    [System.Serializable] // Inspector'da gösterilebilir olmasını sağlıyor.
    public class SwipeEvent : UnityEvent<SwipeType> { }

    public SwipeEvent OnSwiped { get; set; } = new SwipeEvent();

    //public UnityEvent<SwipeEvent> OnSwiped;

    //public System.Action<SwipeType> OnSwiped;

    private void Update()
    {
        HandleSwipe();
    }

    #region Swipe

    void HandleSwipe()
    {

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            beginTouchPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            swipeDelta = Input.mousePosition - beginTouchPos;
        }

        if (swipeDelta.magnitude > 100)
        {
            HandleSwipeState(swipeDelta);
        }

#else

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.magnitude > 100)
            {
                HandleSwipeState(touch.deltaPosition);
            }
        }

#endif

    }

    void HandleSwipeState(Vector2 deltaPosition)
    {
        if (deltaPosition.magnitude > swipeThreshold)
        {
            if (Mathf.Abs(deltaPosition.x) > Mathf.Abs(deltaPosition.y))
            {
                if (deltaPosition.x > 0)
                {
                    OnSwiped?.Invoke(SwipeType.Right);
                }
                else
                {
                    OnSwiped?.Invoke(SwipeType.Left);
                }
            }
            else
            {
                if (deltaPosition.y > 0)
                {
                    OnSwiped?.Invoke(SwipeType.Up);
                }
                else
                {
                    OnSwiped?.Invoke(SwipeType.Down);
                }
            }

            ResetSwipe();
        }
    }

    void ResetSwipe()
    {
        swipeDelta = Vector2.zero;
        isDragging = false;
    }

    #endregion
}
