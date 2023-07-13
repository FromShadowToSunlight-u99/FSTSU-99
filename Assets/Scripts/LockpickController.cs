using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LockpickController : MonoBehaviour
{
    [SerializeField] private PanelController panel;
    [SerializeField] private DoorController door;
    [SerializeField] private float _unlockRange;
    [SerializeField] private float _rotateSpeed = 2;
    [SerializeField] private float _maxTryTime = 3;
    [SerializeField] private Transform _pickTransform;
    [SerializeField] private float _tryTime;
    [SerializeField] private GameObject _otherPickParent;
    [SerializeField] private AnimationCurve _failShake;
    [SerializeField] private AnimationCurve _successShake;
    private float _randomAngle;
    private Vector3 _pickStartingRotation;
    public bool _isPanelOpen;


    private void Start()
    {
        _randomAngle = Random.Range(0, 360);
        _pickStartingRotation = _otherPickParent.transform.eulerAngles;
    }


    private void Update()
    {
        if (!_isPanelOpen) return;

        if (Input.GetKey(KeyCode.A))
        {
            _pickTransform.Rotate(new Vector3(0, 0, _rotateSpeed) * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _pickTransform.Rotate(new Vector3(0, 0, -_rotateSpeed) * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            TryToUnlock();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            _otherPickParent.transform.eulerAngles = _pickStartingRotation;
            LeanTween.cancel(tweenId);
        }
    }


    int tweenId = 0;
    private void TryToUnlock()
    {
        LeanTween.cancel(tweenId);
        float currAngle = _pickTransform.rotation.eulerAngles.z%360;
        if(Mathf.Abs(currAngle-_randomAngle) < _unlockRange)
        {
            tweenId = LeanTween.rotate(_otherPickParent,new Vector3(0,0,60),2).setEase(_successShake).setOnComplete(()=>
            {
                door.OpenDoor();
                panel.ClosePanel();
                }).uniqueId;
        }
        else
        {
            tweenId = LeanTween.rotate(_otherPickParent,new Vector3(0,0, 15),.25f).setEase(LeanTweenType.easeShake).uniqueId;
        }
    }
}
