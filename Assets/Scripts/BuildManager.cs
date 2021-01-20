using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    public static BuildManager instance;

    private void Awake(){
        if (instance !=  null){
            Destroy(instance);
            instance = this;
            return;
        }
        instance = this;
    }

    #endregion 

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    private void Start(){
        turretToBuild = standardTurretPrefab;
    }



}
