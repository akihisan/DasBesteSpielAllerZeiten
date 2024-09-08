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
    [SerializeField] private GameObject[] foodItems;
    public int[] amounts;
    public Sprite[] menus;
    [HideInInspector] public int index;

    void Start(){
    //objects should spawn in front of character (tagged "Character")
        GameObject character = GameObject.FindWithTag("Character");
        spawnPosition = new Vector3(3, 2, character.transform.position.z - 0.7f);
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
        //update amount of food items
        UpdateAmounts();
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
        //only if amount is > 0
        if (foodItems[index].GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            string textNumber = foodItems[index].GetComponentInChildren<TextMeshProUGUI>().text;
            if (amounts[index] > 0)
            {
                //spawn chosen food from prefab
                GameObject foodToSpawn = foodPrefabs[index];
                Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
                for (int i = 0; i < menuButtons.Length; i++)
                {
                    menuButtons[i].GetComponent<Button>().interactable = false;
                }
                //reduce amount of spawned food
                amounts[index]--;
                UpdateAmounts();
            }
        }

    }

    private void UpdateAmounts()
    {
        for(int i = 0; i < foodItems.Length; i++) {
            //foodItems[i].GetComponentInChildren<TextMeshProUGUI>().text = amounts[i].ToString();
            GameObject foodAmount = foodItems[i].gameObject.transform.GetChild(0).gameObject;
            foodAmount.GetComponent<TextMeshProUGUI>().text = amounts[i].ToString();
        }
    }

}
