using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.Changed += Render;
    }

    private void OnDisable()
    {
        _counter.Changed -= Render;
    }

    private void Render(int count) =>
        _text.text = count.ToString();
}
