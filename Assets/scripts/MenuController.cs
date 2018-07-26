using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button generateMapButton;
    [SerializeField]
    private Button doneButton;
    [SerializeField]
    private GameObject bottomButtons;



    void Start()
    {
        generateMapButton.onClick.AddListener(GenerateMap);
        doneButton.onClick.AddListener(DoneMapEdit);
    }

    void GenerateMap()
    {
        Gameboard2.Active.GenerateMap(5, 10);
        GameController.Active.SetGameMode(GameMode.MAP_EDIT);
        bottomButtons.SetActive(true);
    }

    void DoneMapEdit()
    {
        GameController.Active.SetGameMode(GameMode.NORMAL);
        bottomButtons.SetActive(false);
    }

}
