using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterView _view;
    [SerializeField] private float _countTime = 0.5f;

    private WaitForSeconds _delay;
    private Coroutine _counting;
    private int _value = 0;

    private void Awake()
    {
        _delay = new WaitForSeconds(_countTime);
        _view.Render(_value);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counting is null)
            {
                _counting = StartCoroutine(Counting());
            }
            else
            {
                StopCoroutine(_counting);
                _counting = null;
            }
        }
    }

    private IEnumerator Counting()
    {
        while (true)
        {
            yield return _delay;
            _view.Render(++_value);
        }
    }
}
