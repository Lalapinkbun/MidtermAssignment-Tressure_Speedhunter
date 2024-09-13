using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Joystick _joyStick;
    public float _speed = 100;
    public float _rotateSpeed = 100;
    private Rigidbody _rb;
    private float _rotation = 0;
    public Transform _camaraTransform;
    public float _timer = 100;
    public Text _timerText;
    private int _minutes;
    private int _seconds;
    private bool isEnd = false;
    private bool isGotTressure = false;

    public GameObject _winPanel;
    public GameObject _losePanel;
    public Text _loseText;

    public Text _scoreText;
    private int _Score;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            return;
        }
        else if (_timer < 0)
        {
            LosePanel();
            return;
        }
        else if (!isEnd)
        {
            _timer -= Time.deltaTime;
            _minutes = (int)(_timer / 60);
            _seconds = (int)(_timer % 60);
            _timerText.text = _minutes.ToString("00") + "m " + _seconds.ToString("00") + "s Left";
        }
        

        if (_joyStick.Vertical > 0.05)
        {
            _rb.AddRelativeForce(Vector3.forward * _speed * Time.fixedDeltaTime);
        }
        if (_joyStick.Vertical < -0.05)
        {
            _rb.AddRelativeForce(Vector3.back * _speed * Time.fixedDeltaTime);
        }
        if (_joyStick.Horizontal < -0.05)
        {
            _rb.AddRelativeForce(Vector3.left * _speed * Time.fixedDeltaTime);
        }
        if (_joyStick.Horizontal > 0.05)
        {
            _rb.AddRelativeForce(Vector3.right * _speed * Time.fixedDeltaTime);
        }
        ///////////////////////////////////////////////////////////////////////

        //Acceleration
        
        if (Input.acceleration.x > 0.1 || Input.acceleration.x < -0.1)
        {
            transform.Rotate(0, Input.acceleration.x * _rotateSpeed * Time.fixedDeltaTime, 0);
        }
        /*
        if (Input.acceleration.y > 0.1f || Input.acceleration.y < -0.1)
        {
            float upDown = Input.acceleration.y * -_rotateSpeed * Time.fixedDeltaTime;
            _rotation -= upDown;
            _rotation = Mathf.Clamp(_rotation, -90f, 90f);
            _camaraTransform.localRotation = Quaternion.Euler(_rotation, 0, 0);
        }
        */
    }

    public void changeIsEnd(bool value)
    {
        isEnd = value;
    }

    public void gotTressure(bool value)
    {
        isGotTressure = value;
        _Score += (int)(60 - _timer);
    }

    public bool isVaild()
    {
        bool Vailded = false;
        if (isGotTressure && !(_timer < 0))
        {
            Vailded = true;
        }
        return Vailded;
    }

    public void WinningPanel()
    {
        _winPanel.SetActive(true);
        changeIsEnd(true);
        _timer -= Time.deltaTime;
        _minutes = (int)(_timer / 60);
        _seconds = (int)(_timer % 60);
        Debug.Log("Total Time: " + _minutes.ToString("00") + "m " + _seconds.ToString("00") + "s.");

        _Score += (int)(60 - _timer) * 10;
        _scoreText.text = "Score: " + _Score.ToString();
    }

    public void LosePanel()
    {
        _losePanel.SetActive(true);
        changeIsEnd(true);
        _loseText.text = "You have not got the Treasure and Go to the Finish Line in a time";
        _timer -= Time.deltaTime;
        _minutes = (int)(_timer / 60);
        _seconds = (int)(_timer % 60);
        Debug.Log("Total Time: " + _minutes.ToString("00") + "m " + _seconds.ToString("00") + "s.");
    }
}
