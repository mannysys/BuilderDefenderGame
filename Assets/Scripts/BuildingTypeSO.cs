using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * ScriptableObject数据容器，存储数据的一个资源文件
 * 将数据序列化为文件的资源对象
 * 建筑预制体 对象脚本
 */
//定义创建数据资源文件的菜单
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject {

    public string nameString;   //定义资源文件名称
    public Transform prefab;    //预制体

    public ResourceGeneratorData resourceGeneratorData; //负责处理建筑工厂资源数据生成
    public Sprite sprite;   //建筑体精灵图片

}
