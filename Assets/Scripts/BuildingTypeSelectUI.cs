using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 *  管理建筑体UI
 */
public class BuildingTypeSelectUI : MonoBehaviour
{

    //鼠标箭头精灵图片
    [SerializeField] private Sprite arrowSprite;

    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;
    private Transform arrowBtn;

    private void Awake() {
        //找到子物体 btnTemplate 实例
        Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        //加载所有建筑体类型资源文件
        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();

        
        int index = 0;

        //生成数据箭头的实例
        arrowBtn = Instantiate(btnTemplate, transform);
        arrowBtn.gameObject.SetActive(true);

        //设置生成的资源UI实例位置偏移点
        float offsetAmount = +130f;
        arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

        //设置生成的资源UI实例的精灵图片
        arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;
        arrowBtn.Find("image").GetComponent<RectTransform>().sizeDelta = new Vector2(50,50);
        //绑定按钮点击事件
        arrowBtn.GetComponent<Button>().onClick.AddListener(() => {
            //激活点击的建筑体实例
            BuildingManager.Instance.SetActiveBuildingType(null);
        });

        index++;

        //遍历所有建筑体类型资源，并生成实例
        foreach (BuildingTypeSO buildingType in buildingTypeList.list) {
            Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            //设置生成的资源UI实例位置偏移点
            offsetAmount = +130f;
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            //设置生成的资源UI实例的精灵图片
            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;

            //绑定按钮点击事件
            btnTransform.GetComponent<Button>().onClick.AddListener(() => {
                //激活点击的建筑体实例
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            //将建筑体加入字典map中
            btnTransformDictionary[buildingType] = btnTransform;

            index++;
        }

    }

    private void Start() {
        //订阅事件
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;

        UpdateActiveBuildingTypeButton();
    }
    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e) {
        UpdateActiveBuildingTypeButton();
    }


    //更新当前激活的建筑体实例
    private void UpdateActiveBuildingTypeButton() {
        arrowBtn.Find("selected").gameObject.SetActive(false);

        foreach (BuildingTypeSO buildingType in btnTransformDictionary.Keys) {
            Transform btnTransform = btnTransformDictionary[buildingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null) {
            arrowBtn.Find("selected").gameObject.SetActive(true);
        } else {
            btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        }
        
    }


}
