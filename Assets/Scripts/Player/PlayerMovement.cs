using DG.Tweening;
using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    #region Event System
    private void OnEnable()
    {
        SwipeInput.swRight += MoveRight;
        SwipeInput.swLeft += MoveLeft;
        SwipeInput.swUp += MoveUp;
        SwipeInput.swDown += MoveDown;
    }
    private void OnDisable()
    {
        SwipeInput.swRight -= MoveRight;
        SwipeInput.swLeft -= MoveLeft;
        SwipeInput.swUp -= MoveUp;
        SwipeInput.swDown -= MoveDown;
    }


    #endregion

    #region Variables

    [Space, SerializeField]
    private float moveDuration;

    private bool isGameEnd = false;

    [Space, SerializeField]
    private float xAxisPos, minYOrdinate, maxYOrdinate;

    [Space, SerializeField]
    private float HorizontalRotation, VerticalRotation;

    [Space, SerializeField]
    private Ease moveEase = Ease.Linear;

    #endregion

    #region Methods
    private void FixedUpdate()
    {
        if (isGameEnd)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 6);
        }
    }

    public void setIsGameEnd(bool flag)
    {
        isGameEnd = flag;
        if (isGameEnd)
        {
            transform.DOMove(new Vector3(0f, transform.position.y, transform.position.z + 2), .3f);
        }
    }

    public void MoveRight()
    {
        Vector3 newRot = new Vector3(
            transform.rotation.x,
            transform.rotation.y,
            -HorizontalRotation);

        StartCoroutine(XSwipeMovements(newRot, xAxisPos));
    }
    public void MoveLeft()
    {
        Vector3 newRot = new Vector3(
            transform.rotation.x,
            transform.rotation.y,
            HorizontalRotation);

        StartCoroutine(XSwipeMovements(newRot, -xAxisPos));
    }
    public void MoveUp()
    {
        Vector3 newRot = new Vector3(
            -VerticalRotation,
            transform.rotation.y,
            transform.rotation.z);

        StartCoroutine(YSwipeMovements(newRot, maxYOrdinate));
    }
    public void MoveDown()
    {
        Vector3 newRot = new Vector3(
            VerticalRotation,
            transform.rotation.y,
            transform.rotation.z);

        StartCoroutine(YSwipeMovements(newRot, minYOrdinate));
    }
    IEnumerator MoveOnXAxis(float x)
    {
        transform.DOMoveX(x, moveDuration).SetEase(moveEase);
        yield return new WaitForSeconds(moveDuration);
    }
    IEnumerator MoveOnYOrdinate(float y)
    {
        transform.DOMoveY(y, moveDuration).SetEase(moveEase);
        yield return new WaitForSeconds(moveDuration);
    }
    IEnumerator XSwipeMovements(Vector3 newRotation, float xAxis)
    {
        if (!isGameEnd)
        {
            transform.DORotate(newRotation, .1f);
            yield return StartCoroutine(MoveOnXAxis(xAxis));
            transform.DORotate(Vector3.zero, .1f);
        }
    }
    IEnumerator YSwipeMovements(Vector3 newRotation, float yOrdinate)
    {
        if (!isGameEnd)
        {
            transform.DORotate(newRotation, .1f);
            yield return StartCoroutine(MoveOnYOrdinate(yOrdinate));
            transform.DORotate(Vector3.zero, .1f);
        }
    }
    #endregion

}