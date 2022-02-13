using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private ParticleSystem _hitEffect;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartShoot();
    }

    private void StartShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                _animator.SetTrigger("Shoot");
                _shootEffect.Play();
                CheckHit();
            }
        }
    }

    private void CheckHit()
    {
        RaycastHit hit;
        if(Physics.Raycast(_shootEffect.transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<ChangeEnemyMaterial>().ChangeMaterial();
                _hitEffect.transform.position = hit.point;
                _hitEffect.Play();
            }
        }
    }
}
