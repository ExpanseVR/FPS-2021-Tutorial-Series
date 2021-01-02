using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] private int _lightID = 0;

    Renderer _renderer;

    private void OnEnable()
    {
        ConsoleBehaviour.onConsoleUsed += SetActivateLight;
    }

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetActivateLight (int consoleID)
    {
        if (consoleID == _lightID)
            _renderer.material.SetColor("_EmissionColor", Color.green);
    }

    private void OnDisable()
    {
        ConsoleBehaviour.onConsoleUsed -= SetActivateLight;
    }
}
