using System.Collections;
using UnityEngine;


public class Objectshake : MonoBehaviour
{   
    [Header("Shake")]
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeMagnitude = 0.2f;
    

    private bool _isShaking;
    private Vector3 _originalPosition;
    private Coroutine _shakeCoroutine;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }

    public void StartShake()
    {
        if (_isShaking)
            return;

        if (_shakeCoroutine != null) StopCoroutine(_shakeCoroutine);
        _shakeCoroutine = StartCoroutine(ShakeObject());

    }

    public void ResetObject()
    { 
        if ( _shakeCoroutine != null) StopCoroutine(_shakeCoroutine);
        _shakeCoroutine = null;
        _isShaking = false;
        transform.localPosition = _originalPosition;

    }

    private IEnumerator ShakeObject()
    {
        _isShaking = true;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = _originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = _originalPosition;
        _isShaking = false;
        _shakeCoroutine = null;

    }

    public void RefreshOriginalLocal()
    {
            _originalPosition = transform.localPosition;
    
    }
}

