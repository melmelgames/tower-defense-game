using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer nodeRenderer;
    private Color startColor;
    private GameObject turret;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Vector3 offset;

    private void Start(){
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
    }

    private void OnMouseEnter() {
        nodeRenderer.material.color = hoverColor;
    }

    private void OnMouseExit() {
        nodeRenderer.material.color = startColor;
    }

    private void OnMouseDown() {
        if(turret != null){
            Debug.Log("CAN'T BUILD HERE! WEAPON ALREADY IN PLACE!");
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + offset, transform.rotation);        
    }
}
