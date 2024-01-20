using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public int house;
    private int room;
    public Vector3 targetPosition;
    public float speed = 5f;
    public bool cameraMoving = false;

    void Start()
    {
        room = 1;
    }

    void Update() {
        if (cameraMoving) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            if ((transform.position - targetPosition).sqrMagnitude < 0.001f) {
                cameraMoving = false;
            }
        }
    }

    public void MoveRight(){
        if(room < 2){
            targetPosition = transform.position + new Vector3(3.7f, 0, 0);
             cameraMoving = true;
             room++;
        }
    }

    public void MoveLeft(){
        if(room > 1){
            targetPosition = transform.position + new Vector3(-3.7f, 0, 0);
             cameraMoving = true;
             room--;
        }
    }

    public void Enter()
    {
        if(house == 1){
            switch(room){
                case 1: SceneManager.LoadScene("Room1");
                        break;
                case 2: SceneManager.LoadScene("Room1");        //change to correct room once existing
                        break;
            }
        }
    }

}
