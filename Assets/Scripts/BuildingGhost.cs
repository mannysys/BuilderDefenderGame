using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 处理建筑体精灵图片，设置成透明的幽灵形状的
 */
public class BuildingGhost : MonoBehaviour
{

    private GameObject spriteGameObject;

    private void Awake() {
        spriteGameObject = transform.Find("sprite").gameObject;

        Hide();
    }
    private void Start() {
        /*
         * 订阅监听建筑体管理脚本中的，自定义事件
         * += 加等于表示新增一个监听函数，-= 减等于表示删除一个新增的监听函数 
         */
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }
   
    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e) {

        Debug.Log("event handler");
        //获得当前激活的建筑体实例
        if(e.activeBuildingType == null) {
            Hide();
        } else {
            Show(e.activeBuildingType.sprite);
        }
    }

    private void Update() {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }

    private void Show(Sprite ghostSprite) {
        spriteGameObject.SetActive(true);
        //将精灵图片，设置幽灵状态的建筑精灵
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }

    private void Hide() {
        spriteGameObject.SetActive(false);
    }

}
