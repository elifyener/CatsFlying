using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Start()
    {
        Enemy.point = 0;
    }
    void Update()
    {
        _scoreText.text = Enemy.point.ToString();
    }
}
