using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target = default;
    [SerializeField] private float _pivotRotationSpeed = 10;
    [SerializeField] private float _yOffset = 1;
    
    private void Update()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - transform.position;
        direction.y += _yOffset;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _pivotRotationSpeed);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void LoseTarget()
    {
        _target = null;
    }
}