using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private GameObject[] menuButtons;

    void Start(){
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mZCoord);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + mOffset;
        transform.position = new Vector3(curPosition.x, curPosition.y, transform.position.z);
    }

    void OnMouseUp()
    {
        float x = transform.position.x;
        float y = transform.position.y;


        if (x >= -1 && x <= 1.8 && y >= 0 && y <= 4.5)
        {
            Destroy(gameObject);
            for(int i = 0; i < menuButtons.Length; i++){
                menuButtons[i].GetComponent<Button>().interactable = true;
            }
        }
    }


}
