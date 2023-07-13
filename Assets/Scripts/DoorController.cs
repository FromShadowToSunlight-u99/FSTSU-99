using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private PanelController panel;
    [SerializeField] private float _doorOpeningSpeed = .2f;
    [SerializeField] private Transform _doorParent;
    [SerializeField] private GameObject _instructionText;
    private bool _isCharacterInRange;
    private bool _isOpen;
    private float _currentAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        _isCharacterInRange = true;
        if (_isOpen) return;
        _instructionText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;

        _isCharacterInRange = false;
        _instructionText.SetActive(false);
    }

    private void Update()
    {
        if (!_isCharacterInRange||_isOpen) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _instructionText.SetActive(false);
            panel.OpenPanel();
            _isOpen = true;
        }
    }

    public void OpenDoor()
    {
        StartCoroutine(DoorOpening());
    }

    private IEnumerator DoorOpening()
    {
        while (_currentAngle < 90)
        {
            _doorParent.transform.Rotate(new Vector3(0, _doorOpeningSpeed, 0));
            _currentAngle += _doorOpeningSpeed;
            yield return new WaitForSeconds(.02f);
        }
    }
}
