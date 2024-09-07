using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject FoodScreen, desserts, drinks;

    void Start(){
        FoodScreen.SetActive(false);
        desserts.SetActive(false);
        drinks.SetActive(false);
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenFood(){
        FoodScreen.SetActive(true);
    }

    public void CloseMenu(){
        FoodScreen.SetActive(false);
    }


}