using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ScriptableObject数据容器，存储数据的一个资源文件（将数据序列化为文件的资源对象）
 * 定义资源数据实例的文件
 */
[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject {

    public string nameString;
    public Sprite sprite;

}
