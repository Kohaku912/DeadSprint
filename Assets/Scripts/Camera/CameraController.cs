using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    private Transform _viewpointOrigin;
    [SerializeField] private AnimationCurve transitionCurve = 
        AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

    [SerializeField][Range(0.5f, 10.0f)] private float transitionTime = 1.0f;
    
    private float _transitionValue;
    private bool _isMoving = false;
    private UnityAction _onDestination;
    
    // Start is called before the first frame update
    void Start()
    {
        _viewpointOrigin = transform.parent;
        instance = this;
    }

    IEnumerator MoveTransition()
    {
        Vector3 origin = transform.localPosition;
        Quaternion rotOrigin = transform.localRotation;
        while (transform.localPosition.magnitude > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(origin, Vector3.zero,
                transitionCurve.Evaluate(_transitionValue));
            transform.localRotation = Quaternion.Lerp(rotOrigin, Quaternion.identity,
                transitionCurve.Evaluate(_transitionValue));
            _transitionValue += Time.deltaTime / transitionTime;
            yield return new WaitForEndOfFrame();
        }

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _transitionValue = 0.0f;
        _onDestination?.Invoke();
        _isMoving = false;
    }
    
    public void ChangeViewpoint(Transform viewpoint, UnityAction onDestination = null)
    {
        if (_isMoving)
            return;

        _onDestination = onDestination;
        transform.SetParent(viewpoint);
        _isMoving = true;
        StartCoroutine(MoveTransition());
    }
    
    public void ResetViewpoint(UnityAction onDestination = null)
    {
        ChangeViewpoint(_viewpointOrigin, onDestination);
    }
}
