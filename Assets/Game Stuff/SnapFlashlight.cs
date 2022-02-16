using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SnapFlashlight : MonoBehaviour
{
    [SerializeField] Transform originPoint;
    [SerializeField] Transform aimPoint;
    //[SerializeField] Light2D cone;
    //[SerializeField] Light2D spot;
    [SerializeField] Transform cone;
    [SerializeField] Transform spot;
    [SerializeField] CircleCollider2D rangeCollider;
    private float offset = 1f;

    private Light2D coneLight;

    private void Start()
    {
        coneLight = cone.GetComponent<Light2D>();
    }

    private void Update()
    {
        cone.position = originPoint.position;
        spot.position = aimPoint.position + ((transform.position - aimPoint.position).normalized);
        //cone end-point handled by constraint component
        coneLight.pointLightOuterRadius = rangeCollider.radius;
    }
}
