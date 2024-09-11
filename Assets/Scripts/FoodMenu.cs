using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenu : MonoBehaviour
{
    public Image food, menu;
    public GameObject[] foodPrefabs;
    [HideInInspector] public Vector3 spawnPosition;
    public GameObject[] tabs, buttons;
    [HideInInspector] public GameObject[] menuButtons;
    [SerializeField] private GameObject[] foodObjects;
    public Sprite[] menus;
    [HideInInspector] public int index;
    public InventoryScriptable inv;

    [SerializeField] private GameObject FoodScreen, desserts, drinks, message;

    void Start(){
    //objects should spawn in front of character (tagged "Character")
        GameObject character = GameObject.FindWithTag("Character");
        spawnPosition = new Vector3(3, 2, character.transform.position.z - 0.7f);
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
        //update amount of food items
        UpdateAmounts();

        //set all screens inactive
        FoodScreen.SetActive(false);
        desserts.SetActive(false);
        drinks.SetActive(false);
        message.SetActive(false);
    }

    public void OpenFood()
    {
        FoodScreen.SetActive(true);
    }

    public void CloseMenu()
    {
        FoodScreen.SetActive(false);
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

    public void SpawnFood()
    {
        //if there is a food item
        if (inv.foodItems[index] != null)
        {
            //spawn food only if amount is > 0
            if (inv.amounts[index] > 0)
            {
                //spawn chosen food from prefab
                GameObject foodToSpawn = foodPrefabs[index];
                Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
                for (int i = 0; i < menuButtons.Length; i++)
                {
                    menuButtons[i].GetComponent<Button>().interactable = false;
                }
                //reduce amount of spawned food
                inv.amounts[index]--;
                UpdateAmounts();
                //close menu
                CloseMenu();
            }
            //if it is 0, show message
            else
            {
                message.SetActive(true);
            }
        }

    }

    private void UpdateAmounts()
    {
        for(int i = 0; i < foodObjects.Length; i++) {
            GameObject foodAmount = foodObjects[i].gameObject.transform.GetChild(0).gameObject;
            foodAmount.GetComponent<TextMeshProUGUI>().text = inv.amounts[i].ToString();
        }
    }

    public void CloseMessage()
    {
        message.SetActive(false);
    }

}
