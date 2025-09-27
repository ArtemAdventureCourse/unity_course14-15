using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private float _xRotation = 0f;
    [SerializeField] private float _minValue = -160f;
    [SerializeField] private float _maxValue = 160f;
    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        SetCharacterRotation();
    }

    private void SetCharacterRotation()
    {
        _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _minValue, _maxValue);
        _playerBody.Rotate(Vector3.up * _mouseX);
    }
}
