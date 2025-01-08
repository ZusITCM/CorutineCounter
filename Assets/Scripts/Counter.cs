using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [Header("Настройка счетчика")]
    [Tooltip("Задержка счетчика")]
    [SerializeField, Min(0.5f)] private float _counterDelay;

    private Coroutine _coroutine;

    private bool _isCounting;

    public event Action CountViewing;

    public int NumberCounter {  get; private set; } 

    private void Start()
    {
        NumberCounter = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
                _coroutine = StartCoroutine(CountUp());
            else if (_coroutine != null)
                StopCoroutine(_coroutine);
            else
                Debug.Log("Ошибка логики апдейта.");
        }
    }

    private IEnumerator CountUp()
    {
        WaitForSecondsRealtime waitTime = new WaitForSecondsRealtime(_counterDelay);

        while(_isCounting)
        {
            CountViewing?.Invoke();

            NumberCounter++;

            yield return waitTime;
        }
    }
}
