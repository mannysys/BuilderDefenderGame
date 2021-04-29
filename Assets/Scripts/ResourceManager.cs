using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理资源数据
 */
public class ResourceManager : MonoBehaviour {

    //资源管理类静态单例
    public static ResourceManager Instance { get; private set; }

    //定义一个事件
    public event EventHandler OnResourceAmountChanged;
    

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake() {
        Instance = this;

        //初始化map
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        //加载资源集合list
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        //遍历资源集合，然后添加到 map中，key为资源类，value为资源的数量
        foreach(ResourceTypeSO resourceType in resourceTypeList.list) {
            resourceAmountDictionary[resourceType] = 0;
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.T)) {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            //TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary() {

        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys) {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    //更新对应的资源类数量
    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;

        /*
         * 广播该事件，this 表示事件发送者
         * 问号无条件运算符，判断OnResourceAmountChanged 事件是否为null，不为null将其触发
         * Invoke 事件重复调用
         */
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    //根据资源类型名称，返回资源在map 中的对应的资源数值
    public int GetResourceAmount(ResourceTypeSO resourceType) {
        return resourceAmountDictionary[resourceType];
    }


}
