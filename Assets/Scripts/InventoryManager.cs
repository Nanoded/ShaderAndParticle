using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Camera _inventoryCamera;
    [SerializeField] private ParticleSystem _selectedObjectEffect;
    [SerializeField] private GridGenerator _gridGenerator;
    private List<Slot> _slots = new List<Slot>();
    private int _currentSlot = 0;
    [Inject] private PlayerMovement _playerMovement;


    private void Start()
    {
        _inventoryCamera.gameObject.SetActive(false);
        for (int i = 0; i < transform.childCount; i++)
        {
            _slots.Add(transform.GetChild(i).GetComponent<Slot>());
        }
        _selectedObjectEffect.transform.position = _slots[0].transform.position;
    }

    void Update()
    {
        OpenInventory();
        if (_inventoryCamera.gameObject.activeInHierarchy)
        {
            SelectItem();
        }
    }

    private void OpenInventory()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (_inventoryCamera.gameObject.activeInHierarchy)
            {
                _inventoryCamera.gameObject.SetActive(false);
                _playerMovement.gameObject.SetActive(true);
            }
            else
            {
                _inventoryCamera.gameObject.SetActive(true);
                _playerMovement.gameObject.SetActive(false);
            }
        }
    }

    private void SelectItem()
    {
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            _currentSlot += 1;
            CheckSlotCount();
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _currentSlot -= 1;
            CheckSlotCount();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _currentSlot -= _gridGenerator.GetGridSize().x;
            CheckSlotCount();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _currentSlot += _gridGenerator.GetGridSize().x;
            CheckSlotCount();
        }
    }

    private void CheckSlotCount()
    {
        if (_currentSlot < _slots.Count && _currentSlot >= 0)
        {
            _selectedObjectEffect.transform.position = _slots[_currentSlot].gameObject.transform.position;
        }
        else
        {
            _currentSlot = 0;
            _selectedObjectEffect.transform.position = _slots[_currentSlot].transform.position;
        }
    }
}
