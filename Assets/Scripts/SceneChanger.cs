using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject FoodScreen;
    private bool isFood;

    void Start(){
        FoodScreen.SetActive(false);
    }

    void Update(){
        if(isFood){
            FoodScreen.SetActive(true);
        }else{
            FoodScreen.SetActive(false);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenFood(){
        isFood = true;
    }

    public void CloseMenu(){
        isFood = false;
    }


}