using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 管理资源数据文件的集合
 */
[CreateAssetMenu(menuName = "ScriptableObjects/ResourceTypeList")]
public class ResourceTypeListSO : ScriptableObject {

    public List<ResourceTypeSO> list;
    
}
