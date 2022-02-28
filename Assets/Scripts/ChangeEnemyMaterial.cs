using UnityEngine;

public class ChangeEnemyMaterial : MonoBehaviour
{
    [SerializeField] private GameObject _objectWithMaterial;
    [SerializeField] private Material _materialAfterHit;
    private Material _standartMaterial;

    void Start()
    {
        _standartMaterial = _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material;
    }

    public void ChangeMaterial()
    {
        if (_objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material == _standartMaterial)
        {
            _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material = _materialAfterHit;
        }
        else
        {
            _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material = _standartMaterial;
        }
    }
}