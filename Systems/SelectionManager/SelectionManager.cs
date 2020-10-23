using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    private ISelector _selector;
    private IRayProvider _RayProvider;
    private ISelectionResponse _SelectionResponse;

    private Transform _currentSelection;

    private void Awake()
    {
        _selector = GetComponent<ISelector>();
        _RayProvider = GetComponent<IRayProvider>();
        _SelectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        if (_currentSelection != null) _SelectionResponse.OnDeselect(_currentSelection);
        _selector.Check(_RayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();
        if (_currentSelection != null) _SelectionResponse.OnSelect(_currentSelection);
    }

    public Transform GetCurrentSelection() {
        return _currentSelection;
    }
}
