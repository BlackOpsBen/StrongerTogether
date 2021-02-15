using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringArcChecker : MonoBehaviour
{
    private TargetEnemies targetEnemies;

    [SerializeField] Transform arcLimit1;
    [SerializeField] Transform arcLimit2;

    private CircleCollider2D circleCollider;

    float arcSizeDegrees;
    float halfArc;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        targetEnemies = GetComponent<TargetEnemies>();
        arcSizeDegrees = targetEnemies.weapon.GetFiringArc();
        halfArc = arcSizeDegrees / 2;
    }

    // Update is called once per frame
    void Update()
    {
        SetArcRotations();

        Vector2 heading = transform.position + transform.right * targetEnemies.weapon.GetRange();
        Vector2 arc1Heading = transform.position + arcLimit1.right * circleCollider.radius;
        Vector2 arc2Heading = transform.position + arcLimit2.right * circleCollider.radius;

        if (arcSizeDegrees < 360.0f)
        {
            // Draw heading
            Debug.DrawLine(transform.position, heading, Color.red);

            // Draw arc limits
            Debug.DrawLine(transform.position, arc1Heading, Color.white);
            Debug.DrawLine(transform.position, arc2Heading, Color.yellow);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (arcSizeDegrees.Equals(360.0f))
        {
            Gizmos.DrawWireSphere(transform.position, circleCollider.radius);
        }
    }

    private void SetArcRotations()
    {
        Vector3 eulerRotation1 = transform.rotation.eulerAngles;
        Vector3 eulerRotation2 = transform.rotation.eulerAngles;
        eulerRotation1 = new Vector3(eulerRotation1.x, eulerRotation1.y, eulerRotation1.z + halfArc);
        eulerRotation2 = new Vector3(eulerRotation2.x, eulerRotation2.y, eulerRotation2.z - halfArc);
        arcLimit1.rotation = Quaternion.Euler(eulerRotation1);
        arcLimit2.rotation = Quaternion.Euler(eulerRotation2);
    }

    public bool CheckIsInArc(Transform target)
    {
        Quaternion rotTarget = Quaternion.LookRotation(target.position - transform.position);
        Quaternion rotHeading = Quaternion.LookRotation(transform.right);
        float angleBetween = Quaternion.Angle(rotTarget, rotHeading);

        if (angleBetween > halfArc)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
