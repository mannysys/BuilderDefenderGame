using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/**
 * 管理资源UI
 */
public class ResourcesUI : MonoBehaviour {

    private ResourceTypeListSO resourceTypeList;
    private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;

    private void Awake() {
        //加载所有资源类型
        resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        //找到自己的子物体UI
        Transform resourceTemplate = transform.Find("resourceTemplate");
        //设置禁用游戏物体隐藏
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
            //生成实例
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            //设置生成的资源UI实例位置点
            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            //设置生成的资源UI实例的精灵图片
            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            //将生成的资源UI实例加入 map字典中
            resourceTypeTransformDictionary[resourceType] = resourceTransform;
            index++;
        }
    }

    private void Start() {
        //将定义的方法绑定到定义的事件上
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
      
        UpdateResourceAmount();
    }

    //更新UI资源数量的事件
    private void ResourceManager_OnResourceAmountChanged(object sender, EventArgs e) {
        UpdateResourceAmount();
    }


    //更新资源UI上的 显示资源的数量
    private void UpdateResourceAmount() {
        foreach(ResourceTypeSO resourceType in resourceTypeList.list) {
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];

            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }

}
