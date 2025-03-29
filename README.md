# Unity Pluralization
## Motivation:
When working on game has different localizations, pluralization is very tough work.
After searching web, Unity has a package to handle localizations: [com.unity.localization](https://docs.unity3d.com/Packages/com.unity.localization@1.5/manual/index.html). It's based on [SmartFormat](https://github.com/axuno/SmartFormat).

This project is based on Unity's version of *SmartFormat* with following modifications:
- Remove unsed extentions: only keep [PluralLocalizationFormatter](https://github.com/axuno/SmartFormat/wiki/Pluralization-_-PluralLocalizationFormatter)
- GC optimization: testcase reduce GC Alloc from 426B to 102B.

## Usage:
```
public class TestGC : MonoBehaviour
{
    private CultureInfo _cultureEnglish = CultureInfo.GetCultureInfo("en");

    private void Update()
    {
        int number = 2;
        
        // Alloc 102 B
        string result = Smart.Format(_cultureEnglish, "There {0:plural:is 1 item|are {} items}.", number);

        Debug.Log(result);
    }
}

// Output: There are 2 items.
```

## Requirements:
Unity 2021 and forward.