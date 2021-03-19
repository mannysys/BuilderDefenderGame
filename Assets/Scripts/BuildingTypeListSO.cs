using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理建筑类型 对象资源集合
 */
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject {

    public List<BuildingTypeSO> list;


}
  
