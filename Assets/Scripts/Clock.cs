using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Clock : MonoBehaviour
    {
        public static event UnityAction RaiseReachedZero;
        
        private TextMeshProUGUI text;
        private int value;
        private float elapsed = 0f;
        private bool inProgress = false;

        public void RestartTimer(int max)
        {
            value = max + 1;
            DecreaseValue();
            inProgress = true;
            elapsed = 0f;
        }
        
        private void Awake()
        {
            inProgress = false;
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void Update() {
            if (!inProgress)
            {
                return;
            }
            
            elapsed += Time.deltaTime;
            if (elapsed < 1f) {
                return;
            }
            
            elapsed %= 1f;
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
}