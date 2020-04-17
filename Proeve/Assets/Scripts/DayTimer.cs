using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private RectTransform _handTransform = null;
    private float _dayLength;
    private float _dayTime;

    private void Start()
    {
        _dayLength = 360f;
        _dayTime = 0;
    }

    void FixedUpdate()
    {
        _dayTime += Time.deltaTime / 100f;

        float _normalizedDayTime = _dayTime % 1f;

        _handTransform.eulerAngles = new Vector3(0, 0, -_normalizedDayTime * _dayLength * 2f);
        Debug.Log(_handTransform.eulerAngles);
    }
}
