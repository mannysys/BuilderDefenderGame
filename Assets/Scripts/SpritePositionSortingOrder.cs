using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 资源树木管理脚本
 */
public class SpritePositionSortingOrder : MonoBehaviour {

    [SerializeField] private bool runOnce;          //渲染出树木精灵图片，让脚本运行一次，就销毁
    [SerializeField] private float positionOffsetY;  //渲染树木各分支树叶的位置偏移量

    private SpriteRenderer spriteRenderer;  //树木精灵图片


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void LateUpdate() {
        /*
         * 因为y轴数值越大，给y轴数值变成负数，层级越靠后
         * 通过y轴数值，设置渲染精灵图片的排序层级
         */
        float precisiorMultiplier = 5f;
        spriteRenderer.sortingOrder = (int) (-(transform.position.y + positionOffsetY) * precisiorMultiplier);
        
        if(runOnce) {
            //销毁该脚本组件（只运行一次）
            Destroy(this);
        }
    }




}
