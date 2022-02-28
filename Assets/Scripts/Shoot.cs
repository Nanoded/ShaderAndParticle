using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private Camera _playerCamera;
    private Vector3 _rayStartPoint;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rayStartPoint = new Vector3(Screen.width / 2, Screen.height / 2);
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
        Ray ray = _playerCamera.ScreenPointToRay(_rayStartPoint);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
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
