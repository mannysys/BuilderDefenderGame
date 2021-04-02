using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 生成资源数据类
 */
[System.Serializable]
public class ResourceGeneratorData {

    public float timerMax;               //生成资源的时间（多少时间生成一次资源）
    public ResourceTypeSO resourceType;  //资源类型（如：木头、石头、金子）

}
   
