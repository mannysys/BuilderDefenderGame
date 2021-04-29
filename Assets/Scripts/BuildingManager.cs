using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * 管理建筑类型数据资源
 */
public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    //声明一个自定义事件
    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

    //自定义事件返回一个自定义类的属性类型
    public class OnActiveBuildingTypeChangedEventArgs : EventArgs {
        public BuildingTypeSO activeBuildingType;
    }

    //获取到主摄像机实例
    private Camera mainCamera;
    //建筑资源实例（石头、木头等）的集合
    private BuildingTypeListSO buildingTypeList;
    //当前建筑资源实例
    private BuildingTypeSO activeBuildingType;

    private void Awake() {
        Instance = this;

        //加载建筑类型数据资源集合
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }
    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update() {
        /*
         * EventSystem.current.IsPointerOverGameObject()
         * 检查鼠标是否点击在UI上，如果点击到UI上 返回true
         */
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if(activeBuildingType != null) {
                Instantiate(activeBuildingType.prefab, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
            }
        }

        /*if (Input.GetKeyDown(KeyCode.T)) {
            buildingType = buildingTypeList.list[0];
        }   
        if (Input.GetKeyDown(KeyCode.Y)) {
            buildingType = buildingTypeList.list[1];
        }*/
    }



    //设置当前点击事件的，激活建筑体实例
    public void SetActiveBuildingType(BuildingTypeSO buildingType) {
        activeBuildingType = buildingType;


        /*
         * 检查所有脚本中是否有脚本监听该事件，如果有则广播自定义的事件
         */
        OnActiveBuildingTypeChanged?.Invoke(this, 
            new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType }
        );
    }

    //返回当前激活的建筑体实例
    public BuildingTypeSO GetActiveBuildingType() {
        return activeBuildingType;
    }


}
