using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button generateMapButton;
    [SerializeField]
    private Button editMapButton;
    [SerializeField]
    private Button doneButton;
    [SerializeField]
    private GameObject bottomButtons;



    void Start()
    {
        generateMapButton.onClick.AddListener(GenerateMap);
        editMapButton.onClick.AddListener(SetEditMapMode);
        doneButton.onClick.AddListener(DoneMapEdit);
    }

    void GenerateMap()
    {
        Gameboard2.Active.GenerateMap(5, 10);
        SetEditMapMode();
    }

    void SetEditMapMode()
    {
        GameController.Active.SetGameMode(GameMode.MAP_EDIT);
        generateMapButton.gameObject.SetActive(false);
        editMapButton.gameObject.SetActive(false);
        bottomButtons.SetActive(true);
    }


    void DoneMapEdit()
    {
        GameController.Active.SetGameMode(GameMode.MAP);
        generateMapButton.gameObject.SetActive(true);
        editMapButton.gameObject.SetActive(true);
        bottomButtons.SetActive(false);
    }

}
