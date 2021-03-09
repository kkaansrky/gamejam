using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public static float _z;
    private float _speed = 5f;
    public float AmbientSpeed = 100.0f;
    private float _xRangeLeft = -2.6f;
    private float _xRangeRight = 4.6f;
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
            transform.position = new Vector3(_xRangeLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > _xRangeRight)
        {
            transform.position = new Vector3(_xRangeRight, transform.position.y, transform.position.z);
        }
 
        _horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * Time.deltaTime * _speed * _horizontalInput);

        _planeRigidbody.velocity = new Vector3(_horizontalInput, 0, 0);
        _planeRigidbody.rotation = Quaternion.Euler(0, 0, _planeRigidbody.velocity.x * -_tilt);
        //transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
    }
    #endregion
    #region Custom Methods
    
    public static float GetZ()
    {
        return PlayerController._z;
    }
    #endregion
}
