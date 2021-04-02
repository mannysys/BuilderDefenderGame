using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 公共的公开的工具类
 */
public class UtilsClass : MonoBehaviour {

    private static Camera mainCamera;

    //获取一个鼠标位置坐标
    public static Vector3 GetMouseWorldPosition() {
        //获取到主摄像机实例
        if (mainCamera == null) mainCamera = Camera.main;

        //将屏幕上鼠标坐标转换为世界三维坐标
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }


}
