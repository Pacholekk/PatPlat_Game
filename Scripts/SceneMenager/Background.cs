using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private GameObject mainCamera;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    void Start()
    {
        xPosition = transform.position.x;
        mainCamera = GameObject.Find("Main Camera");
    }

    
    void Update()
    {
        float distance = mainCamera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(xPosition * distance, transform.position.y);
    }
}
