using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallxBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    [SerializeField] private float VeticalEffect;
    private float xPosition;
    private float yPosition;
    private float Length;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

   
    void Update()
    {
        float DistanceMoved = cam.transform.position.x *(1-parallaxEffect);
        float Distance = cam.transform.position.x * parallaxEffect; 
        float VerticalDistance = cam.transform.position.y * VeticalEffect;
        transform.position = new Vector3(xPosition + Distance, yPosition + VerticalDistance);

        if (DistanceMoved > xPosition + Length)
            xPosition = xPosition + Length;
        else if(DistanceMoved < xPosition - Length)
            xPosition = xPosition - Length;
    }
}
