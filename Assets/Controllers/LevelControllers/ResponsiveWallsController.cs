using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveWallsController : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;

    void Start()
    {
        AdjustWalls();
    }

    void AdjustWalls()
    {
        Camera mainCamera = Camera.main;

        Vector3 screenBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));

        if (leftWall != null)
        {
            leftWall.transform.position = new Vector3(screenBottomLeft.x - 1, leftWall.transform.position.y, leftWall.transform.position.z);
        }

        if (rightWall != null)
        {
            rightWall.transform.position = new Vector3(screenTopRight.x + 1, rightWall.transform.position.y, rightWall.transform.position.z);
        }
    }
}
