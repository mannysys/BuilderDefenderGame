using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField] private Transform pfWoodHarvester; //木材实例预制体

    private Camera mainCamera;                          //获取到主摄像机实例

    private void Start() {
        mainCamera = Camera.main;  
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(pfWoodHarvester, GetMouseWorldPosition(), Quaternion.identity);
        }

    }

    //获取一个鼠标位置坐标
    private Vector3 GetMouseWorldPosition() {
        //将屏幕上鼠标坐标转换为世界三维坐标
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }





}
