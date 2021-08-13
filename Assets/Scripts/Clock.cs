using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public static event UnityAction RaiseReachedZero;
    public static event UnityAction RaiseReachedFirstThreshold;
    public static event UnityAction RaiseReachedSecondThreshold;

    private TextMeshProUGUI text;
    private int value;
    private float elapsed = 0f;
    private float elapsedTotal = 0f;
    private bool inProgress = false;
    private int max;
    private int firstThreshold;
    private int secondThreshold;

    public void RestartTimer(int max, int firstThreshold, int secondThreshold)
    {
        value = max + 1;
        this.max = max;
        this.firstThreshold = firstThreshold;
        this.secondThreshold = secondThreshold;
        text.color = Color.white;

        DecreaseValue();
        inProgress = true;
        elapsed = 0f;
        elapsedTotal = 0f;
    }

    private void Awake()
    {
        inProgress = false;
        text = GetComponentInChildren<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (!inProgress)
        {
            return;
        }

        elapsed += Time.deltaTime;
        elapsedTotal += Time.deltaTime;
        if (elapsed < 1f)
        {
            return;
        }


        elapsed %= 1f;

        if (elapsedTotal > max - secondThreshold)
        {
            text.color = Color.red;
            RaiseReachedSecondThreshold?.Invoke();
        }
        else if (elapsedTotal > max - firstThreshold)
        {
            text.color = Color.yellow;
            RaiseReachedFirstThreshold?.Invoke();
        }

        DecreaseValue();
    }

    private void DecreaseValue()
    {
        text.text = (--value).ToString();

        if (value != 0)
        {
            return;
        }

        inProgress = false;
        RaiseReachedZero?.Invoke();
    }
}