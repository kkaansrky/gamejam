using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Space]
    [SerializeField]
    float laneChangeSpeed = 4f;

    float lineOffset = 2.5f;

    enum LaneState
    {
        Left = -1,
        Middle = 0,
        Right = 1
    }

    LaneState currentLaneState = LaneState.Middle;

    private void Update()
    {
        transform.localPosition = Vector3.MoveTowards( // Belirli zaman aralığında, şu pozisyona ilerle!
            current: transform.localPosition,
            target: Vector3.right * ((int)currentLaneState * lineOffset),
            maxDistanceDelta: laneChangeSpeed * Time.deltaTime);
    }

    public void OnSwiped(SwipeType swipeType)
    {
        switch (swipeType)
        {
            case SwipeType.Right:

                if (currentLaneState != LaneState.Right)
                {
                    currentLaneState++;
                }

                break;

            case SwipeType.Left:

                if (currentLaneState != LaneState.Left)
                {
                    currentLaneState--;
                }

                break;

            case SwipeType.Up:

                // TODO: Jump state

                break;

            case SwipeType.Down:

                // TODO: Slide state

                break;
            default:
                break;
        }
    }
}
