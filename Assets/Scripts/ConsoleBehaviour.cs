using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConsoleBehaviour : MonoBehaviour
{
    public static event Action<int> onConsoleUsed;

    [SerializeField] private DoorBehaviour _door;
    [SerializeField] private Color _activatedColor;
    [SerializeField] private Light _light;
    [SerializeField] private LightBehaviour _doorLight;
    [SerializeField] private int _consoleID = 0;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        //check to see if player is in collider
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            //interact with the door to unlock it
            _light.color = _activatedColor;
            onConsoleUsed?.Invoke(_consoleID);
        }
    }
}
