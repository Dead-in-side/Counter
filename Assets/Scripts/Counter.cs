using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Counter : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Clicker _clicker;

    private int _count;
    private TextMeshProUGUI _textMeshPro;
    private bool _isPressed = false;
    private Coroutine _coroutine;

    private void Start()
    {
        _count = 0;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text = _count.ToString();
    }

    private void OnEnable()
    {
        _clicker.ClickedButtom += ButtonPressed;
    }

    private void OnDisable()
    {
        _clicker.ClickedButtom -= ButtonPressed;
    }

    private void ButtonPressed()
    {
        _isPressed = !_isPressed;

        if (_isPressed)
        {
            _coroutine = StartCoroutine(IncreaseNumberCoroutine());
        }
        else
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseNumberCoroutine()
    {
        bool isWork = true;

        while (isWork)
        {
            _count++;
            _textMeshPro.text = _count.ToString();

            yield return new WaitForSecondsRealtime(_time);
        }
    }
}
