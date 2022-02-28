using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private int2 _gridSize;
    [SerializeField] private float2 _offset;
    [SerializeField] private InventoryManager _slotsManager;

    [ContextMenu("Generate grid")]
    public void GenerateGrid()
    {
        var cellsize = _slotPrefab.GetComponent<MeshRenderer>().bounds.size;
        var position = _slotsManager.transform.position;
        for (int x = 0; x < _gridSize.x; x++)
        {
            position.x = _slotsManager.transform.position.x;
            for (int y = 0; y < _gridSize.y; y++)
            {
                var cell = Instantiate(_slotPrefab, position, _slotPrefab.transform.rotation, _slotsManager.transform);
                position.x += _offset.x + cellsize.x/2;
            }
            position.y -= _offset.y + cellsize.y/2;
        }
    }

    public int2 GetGridSize()
    {
        return _gridSize;
    }
}
