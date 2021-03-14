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

    [Space, SerializeField]
    private float xAxisPos, minYOrdinate, maxYOrdinate;

    [Space, SerializeField]
    private float HorizontalRotation, VerticalRotation;

    #endregion

    #region Methods
    public void MoveRight()
    {
        Debug.Log("Swiped To Right");

        Vector3 newPos = new Vector3(
            Mathf.Clamp(xAxisPos, -xAxisPos, xAxisPos), 
            transform.position.y, 
            transform.position.z);
        transform.Translate(Vector3.forward*Time.deltaTime*6);

        Vector3 newRot = new Vector3(
            transform.rotation.x,
            transform.rotation.y,
            -HorizontalRotation);

        StartCoroutine(DoMove(newPos, newRot));
    }
    public void MoveLeft()
    {
        Debug.Log("Swiped To Left");

        Vector3 newPos = new Vector3(
            Mathf.Clamp(-xAxisPos, -xAxisPos, xAxisPos),
            transform.position.y, 
            transform.position.z);

        Vector3 newRot = new Vector3(
            transform.rotation.x,
            transform.rotation.y,
            HorizontalRotation);

        StartCoroutine(DoMove(newPos, newRot));
    }
    public void MoveUp()
    {
        Debug.Log("Swiped To Up");

        Vector3 newPos = new Vector3(
            transform.position.x,
            Mathf.Clamp(maxYOrdinate, minYOrdinate, maxYOrdinate),
            transform.position.z);

        Vector3 newRot = new Vector3(
            -VerticalRotation,
            transform.rotation.y,
            transform.rotation.z);

        StartCoroutine(DoMove(newPos, newRot));
    }
    public void MoveDown()
    {
        Debug.Log("Swiped To Down");

        Vector3 newPos = new Vector3(
                    transform.position.x,
                    Mathf.Clamp(minYOrdinate, minYOrdinate, maxYOrdinate),
                    transform.position.z);

        Vector3 newRot = new Vector3(
            VerticalRotation,
            transform.rotation.y,
            transform.rotation.z);

        StartCoroutine(DoMove(newPos, newRot));
    }

    IEnumerator DoMove(Vector3 newPosition, Vector3 newRotation)
    {
        transform.DORotate(newRotation, .1f);
        yield return StartCoroutine(MoveThePlayer(newPosition));
        transform.DORotate(Vector3.zero, .1f);
    }

    IEnumerator MoveThePlayer(Vector3 newPosition)
    {
        transform.DOMove(newPosition, moveDuration);
        yield return new WaitForSeconds(moveDuration);
    }
    #endregion

}