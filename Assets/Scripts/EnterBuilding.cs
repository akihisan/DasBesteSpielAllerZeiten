using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBuilding : MonoBehaviour
{
    public string Scene;

    void OnMouseUp(){
    //use collider -> when clicked it will change the scene
        SceneManager.LoadScene(Scene);
    }
}
