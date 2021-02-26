using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 管理建筑类型 对象脚本组
 */
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject {

    public List<BuildingTypeSO> buildingTypeList;


}
  
