using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenu : MonoBehaviour
{
    public Image food, menu;
    public GameObject[] foodPrefabs;
    private Vector3 spawnPosition;
    public GameObject[] tabs;
    public GameObject[] buttons;
    public Sprite[] menus;
    private int index;

    void Start(){
        spawnPosition = new Vector3(3, 2, -4);
    }

    void OnEnable(){
        food.sprite = null;
    }

    public void ChangePicture(Sprite currentFood){
        food.sprite = currentFood;
    }

    public void ChangeMenu(int active){
        menu.sprite = menus[active];
        for(int i = 0; i < 3; i++){
            tabs[i].SetActive(false);
        }
        tabs[active].SetActive(true);
        food.sprite = null;
    }

    public void ActivateButtons(int active){
        for(int i = 0; i < 3; i++){
            buttons[i].SetActive(false);
        }
        buttons[active].SetActive(true);
    }

    public void SetIndex(int i){
        index = i;
    }

    public void SpawnFood(){
        GameObject foodToSpawn = foodPrefabs[index];
        Instantiate(foodToSpawn, spawnPosition, Quaternion.identity);
    }
}
