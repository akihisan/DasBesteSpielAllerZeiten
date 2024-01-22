using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenu : MonoBehaviour
{
    public Image food, menu;
    public GameObject[] foodPrefabs;
    private Vector3 spawnPosition;
    public GameObject[] tabs, buttons;
    private GameObject[] menuButtons;
    public Sprite[] menus;
    private int index;

    void Start(){
    //objects should spawn in front of character (tagged "Character")
        GameObject character = GameObject.FindWithTag("Character");
        spawnPosition = new Vector3(3, 2, character.transform.position.z - 1);
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
    }

    void OnEnable(){
    //start with not showing any food on the right side of the menu
        food.sprite = null;
    }

    public void ChangePicture(Sprite currentFood){
    //once clicked on, show current food on right side of menu
        food.sprite = currentFood;
    }

    public void ChangeMenu(int active){
    //to make it look like the tab is on the current side of the menu
        menu.sprite = menus[active];
        for(int i = 0; i < 3; i++){
            tabs[i].SetActive(false);
        }
        tabs[active].SetActive(true);
        food.sprite = null;
    }

    public void ActivateButtons(int active){
    //only show the buttons (text) of the current part of the menu
        for(int i = 0; i < 3; i++){
            buttons[i].SetActive(false);
        }
        buttons[active].SetActive(true);
    }

    public void SetIndex(int i){
    //index saves food that was last clicked on (chosen in menu)
        index = i;
    }

    public void SpawnFood(){
    //spawn chosen food from prefab
        GameObject foodToSpawn = foodPrefabs[index];
        Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
        for(int i = 0; i < menuButtons.Length; i++){
            menuButtons[i].GetComponent<Button>().interactable = false;
        }
    }
}
