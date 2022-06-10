using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour
{
    [SerializeField] private Image _catImage0;
    [SerializeField] private Image _catImage1;
    [SerializeField] private Image _catImage2;

    public static float _catHealth = 3;

    void Start()
    {
        _catHealth = 3;
    }
    void Update()
    {
        switch (_catHealth)
        {
            case 2:
                var tempColor0 = _catImage0.color;
                tempColor0.a = 0.5f;
                _catImage0.color = tempColor0;
            break;
            case 1:
                var tempColor1 = _catImage1.color;
                tempColor1.a = 0.5f;
                _catImage1.color = tempColor1;
            break;
            case 0:
                var tempColor2 = _catImage2.color;
                tempColor2.a = 0.5f;
                _catImage2.color = tempColor2;
            break;
        }
    }
}

