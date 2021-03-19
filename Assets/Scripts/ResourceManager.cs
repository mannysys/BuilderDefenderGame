using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理资源数据
 */
public class ResourceManager : MonoBehaviour {

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake() {
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        //加载资源集合list
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        //遍历资源集合，然后添加到 map中，key为资源类，value为资源的数量
        foreach(ResourceTypeSO resourceType in resourceTypeList.list) {
            resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)) {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() {

        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys) {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    //更新对应的资源类数值
    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;
    }




}
