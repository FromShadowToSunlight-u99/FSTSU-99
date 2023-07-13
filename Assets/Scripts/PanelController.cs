using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private LockpickController _lockpickController;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private GameObject panel;

    public void OpenPanel()
    {
        _lockpickController._isPanelOpen = true;
        thirdPersonController.CancelMovement();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        _lockpickController._isPanelOpen = false;
        thirdPersonController.EnableMovement();
        panel.SetActive(false);
    }
}
