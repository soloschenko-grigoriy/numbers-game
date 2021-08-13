using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Clock : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private int value;

        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void RestartTimer(int max)
        {
            value = max + 1;
            InvokeRepeating(nameof(SetValue), 0f, 1f);
        }

        private void SetValue()
        {
            text.text = (--value).ToString();
        }
    }
}