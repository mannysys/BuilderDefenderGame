using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理建筑类型数据资源
 */
public class BuildingManager : MonoBehaviour {

    //获取到主摄像机实例
    private Camera mainCamera;
    //建筑资源实例（石头、木头等）的集合
    private BuildingTypeListSO buildingTypeList;
    //当前建筑资源实例
    private BuildingTypeSO buildingType;

    private void Awake() {
        //加载建筑类型数据资源集合
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[0];
    }
    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            buildingType = buildingTypeList.list[0];
        }   
        if (Input.GetKeyDown(KeyCode.Y)) {
            buildingType = buildingTypeList.list[1];
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
