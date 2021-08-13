using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ContinueBtn continueBtn;

    private void Start()
    {
        continueBtn.gameObject.SetActive(SaveLoadLocalFile.HasSavings());
    }
}
