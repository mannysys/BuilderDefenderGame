using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour {

    //获得插件CM vcam1 虚拟相机实例
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float orthographicSize;
    private float targetOrthographicSize;

    private void Start() {
        //获得相机的初始缩放大小
        orthographicSize = cinemachineVirtualCamera.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    private void Update() {
        HandleMovement();
        HandleZoom();
    }

    /*
     * 获得键盘上的方向键，水平轴和垂直轴的移动数值
     * 使用键盘方向键，控制相机方向和移动速度
     */
    private void HandleMovement() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, y).normalized;
        float moveSpeed = 30f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    /*
     * 使用鼠标滚轮，控制相机的缩小和放大
     */
    private void HandleZoom() {
        float zoomAmount = 2f;
        // -Input 前面加减号表示使方向反过来
        targetOrthographicSize += -Input.mouseScrollDelta.y * zoomAmount;

        //返回限制在最小值和最大值之间的数值
        float minOrthographicSize = 10;
        float maxOrthographicSize = 30;
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, minOrthographicSize, maxOrthographicSize);

        //使用插值，做个平滑缩放速度
        float zoomSpeed = 5f;
        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamera.m_Lens.OrthographicSize = orthographicSize;
    }






}
