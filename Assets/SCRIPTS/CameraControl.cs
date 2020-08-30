using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    int min;
    int max;
    int result = 0;
    public int change_speed = 5;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Change());
        }
    }

    private IEnumerator Change()
    {
        var cameraMove = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
        int delta = (max - min) / change_speed;
        result = min;
        for(int i = 0;i <change_speed;i++)
        {
            result += delta;
            cameraMove.m_ScreenX = (float)0.1 * result;
            yield return new WaitForSeconds(0.1f);
        }
        cameraMove.m_ScreenX = (float)0.5 * result;
        StopCoroutine(Change());
    }
}
