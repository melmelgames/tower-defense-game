using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 30f;
    [SerializeField] private float panBorderThickness = 10f;
    [SerializeField] private float scrollSpeed = 30f;
    [SerializeField] private float scrollMinY = 10f;
    [SerializeField] private float scrollMaxY = 80f;
    private bool enableCameraMovement = true;

    private void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            enableCameraMovement = !enableCameraMovement;
        }

        if(!enableCameraMovement){
            return;
        }
        
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness){
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness){
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness){
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness){
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll  = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, scrollMinY, scrollMaxY);
        transform.position = pos;
    }


}
