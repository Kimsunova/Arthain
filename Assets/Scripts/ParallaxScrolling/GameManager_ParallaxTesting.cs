using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ParallaxTesting : MonoBehaviour
{
    public Transform[] backgrounds;     //arrays of all backgrounds/foregrounds to be parallaxed
    public float[] parallaxScales;     //proportion of camera's movement for moving backgrounds
    public float smoothing = 1f;        //how smooth parallax will be

    private Transform cam;
    private Vector3 previousCameraPosition;
    private int backgroundsLength;

    private float parallax, backgroundTargetPosX;

    private void Awake()
    {
        cam = Camera.main.transform;
        previousCameraPosition = cam.position;
        backgroundsLength = backgrounds.Length;
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = -backgrounds[i].position.z;
        }

    }

    void LateUpdate()
    {
        for (int i = 0; i < backgroundsLength; i++)
        {
            parallax = (previousCameraPosition.x - cam.position.x) * parallaxScales[i];            
            backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCameraPosition = cam.position;

    }
}
