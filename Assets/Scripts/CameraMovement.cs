using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public int house, maxRooms;
    private int room;
    private Vector3 targetPosition;
    private float speed = 5f;
    private bool cameraMoving = false;

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

        // Call MoveRight() when the right arrow key is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveRight();
        }

        // Call MoveLeft() when the left arrow key is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLeft();
        }
    }

    public void MoveRight(){
    //only move to the right if not already on last room
        if(room < maxRooms){
            targetPosition = transform.position + new Vector3(3.7f, 0, 0);
             cameraMoving = true;
             room++;
        }
    }

    public void MoveLeft(){
    //only move to the left if not already on first room
        if(room > 1){
            targetPosition = transform.position + new Vector3(-3.7f, 0, 0);
             cameraMoving = true;
             room--;
        }
    }

}
