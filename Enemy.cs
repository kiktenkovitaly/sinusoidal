using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float Speed = 0.1f;
    private float Frequency = 3f;
    private float Magnitude = 0.01f;

    private bool UseSine;
    private bool SinDirection;

    private Vector3 Position;
    private Transform TargetPlayer;

    private void OnEnable()
    {
        LookAtTarget();
    }

    public void LookAtTarget()
    {
        Vector3 vectorToTarget = TargetPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = qt;
        SinDirection = Random.value > 0.5f;
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Position = Vector3.MoveTowards(transform.position, TargetPlayer.position, Speed * Time.deltaTime);
        Vector3 direction = SinDirection ? transform.up : -transform.up;
        transform.position = UseSine
                ? Position + direction * Mathf.Sin(Time.time * Frequency) * Magnitude
                : Position;
    }
}