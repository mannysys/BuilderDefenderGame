using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ScriptableObject数据容器，存储数据的一个资源文件
 * 
 * 建筑预制体 对象脚本
 * 
 */
//定义菜单
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject {

    public string nameString;   //定义资源文件名称
    public Transform prefab;    //预制体



   
}
