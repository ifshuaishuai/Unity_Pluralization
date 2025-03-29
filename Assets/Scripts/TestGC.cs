using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;

public class TestGC : MonoBehaviour
{
    private CultureInfo _cultureEnglish = CultureInfo.GetCultureInfo("en");

    private void Update()
    {
        int number = 2;
        
        // 362 B
        string result = Smart.Format(_cultureEnglish, "There {0:plural:is 1 item|are {} items}.", number);
    }
}
