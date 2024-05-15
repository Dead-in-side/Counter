using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Counter : MonoBehaviour
{
    [SerializeField] private float _time;

    private int _counter;
    private TextMeshProUGUI _textMeshPro;
    private bool _isPressed = false;

    public event Action ClickButtom;

    private void Start()
    {
        _counter = 0;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text = _counter.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickButtom?.Invoke();
        }
    }

    private void OnEnable()
    {
        ClickButtom += ButtonPressed;
    }

    private void OnDisable()
    {
        ClickButtom -= ButtonPressed;
    }

    private void ButtonPressed()
    {
        _isPressed = !_isPressed;

        if (_isPressed)
        {
            StartCoroutine(CounterCorutine());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator CounterCorutine()
    {
        while (true)
        {
            _counter++;
            _textMeshPro.text = _counter.ToString();

            yield return new WaitForSecondsRealtime(_time);
        }
    }
}
