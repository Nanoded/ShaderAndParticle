using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyMaterial : MonoBehaviour
{
    [SerializeField] private GameObject _objectWithMaterial;
    [SerializeField] private Material _materialAfterHit;
    private Material _standartMaterial;
    private Material _currentMaterial;

    void Start()
    {
        _standartMaterial = _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material;
        //_currentMaterial = GetComponentInChildren<SkinnedMeshRenderer>().material;
        //_currentMaterial = _objectWithMaterial.GetComponent<SkinnedMeshRenderer>().material;
        //_standartMaterial = _currentMaterial;
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