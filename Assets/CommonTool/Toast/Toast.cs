﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : BaseUIForms
{
    public Text ToastText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Display(object uiFormParams)
    {
        base.Display(uiFormParams);

        ToastText.text = uiFormParams.ToString();
        StartCoroutine(nameof(autoCloseToast));
    }

    private IEnumerator autoCloseToast()
    {
        yield return new WaitForSeconds(2);
        CloseUIForm(GetType().Name);
    }

}
