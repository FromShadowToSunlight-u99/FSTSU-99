using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    [SerializeField] private Transform _characterParent;
    [SerializeField] private Transform _startingPoint;

    private void Start()
    {
        _characterParent.position = _startingPoint.position;        
    }
}
