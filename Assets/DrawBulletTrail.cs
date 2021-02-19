using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBulletTrail : MonoBehaviour
{
    [SerializeField] Transform muzzlePosition;

    private LineRenderer lr;

    private float fade = 0f;
    [SerializeField] float fadeSpeed = 1f;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fade -= Time.deltaTime * fadeSpeed;
        lr.startColor = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, fade);
        lr.endColor = new Color(lr.endColor.r, lr.endColor.g, lr.endColor.b, fade);
    }

    public void Draw(Vector3 dest)
    {
        Debug.Log("Drawing bullet");
        fade = 1f;
        lr.SetPosition(0, muzzlePosition.position);
        lr.SetPosition(1, dest);
    }
}
