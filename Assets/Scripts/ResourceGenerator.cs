using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理生成资源的
 */
public class ResourceGenerator : MonoBehaviour {

    private BuildingTypeSO buildingType;  //获取到建筑体实例
    private float timer;                  
    private float timerMax;               //生成资源的时间间隔   

    private void Awake() {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    }
    private void Update() {
        // deltaTime表示从上一帧到当前帧的时间，以秒为单位
        timer -= Time.deltaTime;
        if(timer <= 0f) {
            timer += timerMax;

            //根据建筑工厂类型，生成资源
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
        }

    }




}
