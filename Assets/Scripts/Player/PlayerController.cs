using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public static float _z;
    private float _speed = 5f;
    public float AmbientSpeed = 100.0f;
    public float SwipeSpeed = 0.5f;
    private float _xRangeLeft = -2.6f;
    private float _xRangeRight = 2.6f;
    private float _tilt = 3;
    private float _horizontalInput;   
    private Rigidbody _planeRigidbody;
    #endregion

    #region Main Methods
    void Awake()
    {
        _planeRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _z = transform.position.z;

        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (transform.position.x < _xRangeLeft)
        {
            transform.position = new Vector3(
                _xRangeLeft, 
                transform.position.y, 
                transform.position.z
                );
        }
        else if (transform.position.x > _xRangeRight)
        {
            transform.position = new Vector3(
                _xRangeRight, 
                transform.position.y, 
                transform.position.z
                );
        }
 
        _horizontalInput = Swipe();

        transform.Translate(Vector3.right * Time.deltaTime * _speed * _horizontalInput);

        _planeRigidbody.velocity = new Vector3(_horizontalInput, 0, 0);
        _planeRigidbody.rotation = 
            Quaternion.Euler(0, 0, _planeRigidbody.velocity.x * -_tilt);
        //transform.Rotate(Vector3.up, Time.deltaTime * 0.3f * _horizontalInput);
         }
    #endregion

    #region Custom Methods
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe = Vector2.zero;

    public float Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(
                    secondPressPos.x - firstPressPos.x, 
                    secondPressPos.y - firstPressPos.y
                    );

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe left
                if (currentSwipe.x < 0 && (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("left");
                    _horizontalInput = -SwipeSpeed;
                    return _horizontalInput;
                }
                //swipe right
                if (currentSwipe.x > 0 && (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
                {
                    Debug.Log("right");
                    _horizontalInput = SwipeSpeed;
                    return _horizontalInput;
                }
            }
        }
        return _horizontalInput;
    }
    public static float GetZ()
    {
        return PlayerController._z;
    }
    #endregion
}
