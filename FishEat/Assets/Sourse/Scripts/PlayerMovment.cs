using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float _firstLetter, _secondLetter;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _forceRigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpCount;
    [SerializeField] private float _speed;
    [SerializeField] private Mass _mass;
    [SerializeField] private float _force;
    private float _killCounter;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log("I need more power!" + " " + _mass.Amount);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(0, 0, _speed);

        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(0, 0, -_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = new Vector3(_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = new Vector3(-_speed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);

        if (collision.gameObject.GetComponent<Mass>())
        {
            if (_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount)
            
            {
                _mass.Amount += collision.gameObject.GetComponent<Mass>().Amount;
                 transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);
                Destroy(collision.gameObject);
                _killCounter++;
                Debug.Log("You are not prepared!" + " " + _killCounter + " " + "the mass is growing" + _mass.Amount);
            }
            else
            {
                Destroy(gameObject); 
                Debug.Log("Ill be back");
            }
        }
        Vector3 normalVector = (collision.transform.position + transform.position).normalized;
        _forceRigidbody.AddForce(normalVector * _force, ForceMode.Impulse);
    }
}


