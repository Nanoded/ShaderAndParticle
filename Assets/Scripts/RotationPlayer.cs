using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlayer : MonoBehaviour
{
    [SerializeField] private float _senitivity;
    private float _moveXAxis;
    private Quaternion _newRotationValue;

    private void Update()
    {
        _moveXAxis += Input.GetAxis("Horizontal") * _senitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.x, _moveXAxis, transform.rotation.z);
    }
}
