using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _senitivity;
    [SerializeField] private float _moveSpeed;
    private CharacterController _characterController;
    private float _moveXAxis;
    private float _moveYAxis;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    private void RotatePlayer()
    {
        _moveXAxis += Input.GetAxis("Horizontal") * _senitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.x, _moveXAxis, transform.rotation.z);
    }

    private void MovePlayer()
    {
        _moveYAxis = Input.GetAxis("Vertical") * _moveSpeed;
        _characterController.Move(transform.forward * _moveYAxis);
    }
}
