using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private int _doorID = 0;
    [SerializeField] private bool _isLockable = false;
    [SerializeField] private bool _staysOpen = false;

    private Animator _animator;
    private bool _isLocked;

    private void OnEnable()
    {
        ConsoleBehaviour.onConsoleUsed += SetLockedState;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();

        if (_isLockable)
            _isLocked = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if door is locked
        if (!_isLocked)
        {
            //if not locked open door
            _animator.SetBool("DoorOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if is not set to _staysOpen, close door when player leaves collider
        if (!_staysOpen)
            _animator.SetBool("DoorOpen", false);
    }

    //set lock state of door
    public void SetLockedState (int consoleID)
    {
        if (consoleID == _doorID)
            _isLocked = false;
    }

    private void OnDisable()
    {
        ConsoleBehaviour.onConsoleUsed -= SetLockedState;
    }
}
