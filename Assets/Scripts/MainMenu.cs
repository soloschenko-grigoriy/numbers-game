using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ContinueBtn continueBtn;

    private void Start()
    {
        var hasSavings = SaveLoadLocalFile.HasSavings();

        Debug.Log(hasSavings);
        continueBtn.gameObject.SetActive(hasSavings);
    }
}
