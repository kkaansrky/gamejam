using UnityEngine;
public enum SwipeState
{
    Default = 0,
    Right,
    Left,
    Up,
    Down
}
public class SwipeInput : MonoBehaviour
{
    // If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
    public const float MAX_SWIPE_TIME = 0.5f;

    // Factor of the screen width that we consider a swipe
    // 0.17 works well for portrait mode 16:9 phone
    public const float MIN_SWIPE_DISTANCE = 0.17f;


    public bool debugWithArrowKeys = true;

    Vector2 startPos;
    float startTime;

    public delegate void SwipeAction();
    public static event SwipeAction swRight;
    public static event SwipeAction swLeft;
    public static event SwipeAction swUp;
    public static event SwipeAction swDown;
    public SwipeState SwipeState
    {
        get
        {
            return swipeState;
        }

        set
        {
            swipeState = value;

            switch (swipeState)
            {
                case SwipeState.Default:
                    break;

                case SwipeState.Right:
                    if (swRight != null)
                        swRight();
                    break;

                case SwipeState.Left:
                    if (swLeft != null)
                        swLeft();
                    break;

                case SwipeState.Up:
                    if (swUp != null)
                        swUp();
                    break;

                case SwipeState.Down:
                    if (swDown != null)
                        swDown();
                    break;

                default:
                    break;
            }
        }
    }
    public SwipeState swipeState = SwipeState.Default;

    public void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(
                    t.position.x / (float)Screen.width, 
                    t.position.y / (float)Screen.width
                    );
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                    return;

                Vector2 endPos = new Vector2(
                    t.position.x / (float)Screen.width, 
                    t.position.y / (float)Screen.width
                    );

                Vector2 swipe = new Vector2(
                    endPos.x - startPos.x, 
                    endPos.y - startPos.y
                    );

                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                    return;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        SwipeState = SwipeState.Right;
                    }
                    else
                    {
                        SwipeState = SwipeState.Left;
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        SwipeState = SwipeState.Up;
                    }
                    else
                    {
                        SwipeState = SwipeState.Down;
                    }
                }
            }
        }

        if (debugWithArrowKeys)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SwipeState = SwipeState.Down;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SwipeState = SwipeState.Up;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SwipeState = SwipeState.Right;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SwipeState = SwipeState.Left;
            }
        }
    }
}
