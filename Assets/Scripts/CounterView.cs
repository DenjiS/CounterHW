using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Render(int count) =>
        _text.text = count.ToString();
}
