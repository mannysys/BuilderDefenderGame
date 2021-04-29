using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理生成资源的
 */
public class ResourceGenerator : MonoBehaviour {

    private ResourceGeneratorData resourceGeneratorData;

    private float timer;                  
    private float timerMax;  //生成资源的时间间隔   

    private void Awake() {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
    }

    private void Start() {

        //创建一个2d的圆形碰撞体，设置圆形的范围半径
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratorData.resourceDetectionRadius);

        int nearbyResourceAmount = 0;
        foreach(Collider2D collider2D in collider2DArray) {
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if(resourceNode != null) {
                // It's a resource node!
                if(resourceNode.resourceType == resourceGeneratorData.resourceType) {
                    // Same type!
                    nearbyResourceAmount++;
                }
            }
        }

        //限制资源数量最小和最大范围
        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourceGeneratorData.maxResourceAmount);
       
        if(nearbyResourceAmount == 0) {
            // No resource nodes nearby
            // Disable resource generator
            enabled = false;
        } else {
            timerMax = (resourceGeneratorData.timerMax / 2f) +
                resourceGeneratorData.timerMax * 
                (1 - (float)nearbyResourceAmount / resourceGeneratorData.maxResourceAmount);
        }

        Debug.Log("资源 ： " + nearbyResourceAmount + "; timerMax: " + timerMax);
    }


    private void Update() {
        // deltaTime表示从上一帧到当前帧的时间，以秒为单位
        timer -= Time.deltaTime;
        if(timer <= 0f) {
            timer += timerMax;

            //根据建筑工厂类型，生成资源
            ResourceManager.Instance.AddResource(resourceGeneratorData.resourceType, 1);
        }

    }




}
