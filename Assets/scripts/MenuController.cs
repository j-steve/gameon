using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button generateMapButton;

    void Start()
    {
        generateMapButton.onClick.AddListener(GenerateMap);
    }

    void GenerateMap()
    {
        Gameboard2.Active.GenerateMap(5, 10);
    }

}
