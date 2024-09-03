using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private const int LeftMouseButtonNumber = 0;

    [SerializeField] private float _countTime = 0.5f;

    private WaitForSeconds _delay;
    private Coroutine _counting;
    private int _value = 0;

    public event UnityAction<int> Changed;

    private void Awake()
    {
        _delay = new WaitForSeconds(_countTime);
    }

    private void Start()
    {
        Changed?.Invoke(_value);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButtonNumber))
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
            Changed?.Invoke(++_value);
        }
    }
}
