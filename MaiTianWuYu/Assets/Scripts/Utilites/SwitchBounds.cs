using UnityEngine;
using Cinemachine;

/**
 * This script is used to switch the bounds of the camera.
 * It is used to switch the bounds of the camera when the player enters a new scene.
 * It is also used to switch the bounds of the camera when the player collides with a switch bound trigger.
 */
public class SwitchBounds : MonoBehaviour
{

    private void Start(){
        SwitchConfinerShape(); 
    }

    private void SwitchConfinerShape(){
        PolygonCollider2D confinerShape = GameObject.FindGameObjectWithTag("BoundsConfiner").GetComponent<PolygonCollider2D>();
        
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        
        confiner.m_BoundingShape2D = confinerShape;

        confiner.InvalidatePathCache();// 清除缓存
    }
}
