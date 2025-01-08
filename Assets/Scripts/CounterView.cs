using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterView;

    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountViewing += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.CountViewing -= DisplayCount;
    }

    public void DisplayCount()
    {
        _counterView.text = _counter.NumberCounter.ToString();
    }
}
