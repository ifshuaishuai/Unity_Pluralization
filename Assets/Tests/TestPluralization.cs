using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using UnityEngine.TestTools;

public class TestPluralization
{
    private CultureInfo _cultureEnglish = CultureInfo.GetCultureInfo("en");
    
    [Test]
    public void OneItem()
    {
        int number = 1;
        
        string result = Smart.Format(_cultureEnglish, "There {0:plural:is 1 item|are {} items}.", number);
        string expected = "There is 1 item.";
        
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void TwoItems()
    {
        int number = 2;
        
        string result = Smart.Format(_cultureEnglish, "There {0:plural:is 1 item|are {} items}.", number);
        string expected = "There are 2 items.";
        
        Assert.AreEqual(expected, result);
    }
}
