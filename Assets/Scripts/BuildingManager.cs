using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField] private BuildingTypeSO buildingType; //建筑体类型实例

    private Camera mainCamera;   //获取到主摄像机实例
   
    private void Start() {
        mainCamera = Camera.main;

        Debug.Log(Resources.Load<BuildingTypeListSO>("BuildingTypeList"));
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
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
