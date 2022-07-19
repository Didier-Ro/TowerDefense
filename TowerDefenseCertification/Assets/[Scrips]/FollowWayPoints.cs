using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] private string _pathName = default;
    [SerializeField] private List<Vector3> _wayPointsPosition = new List<Vector3>();
    private int _currentTime = default;

    void Start()
    {
        StartCoroutine(MoveToNextWayPoint());
    }

    private void GetWayPoints()
    {
        Transform path = GameObject.Find(_pathName).transform;
        for (int i = 0; i < path.childCount; i++)
        {
            _wayPointsPosition.Add(path.GetChild(i).position);
        }
    }

    IEnumerator MoveToNextWayPoint()
    {
        if(_wayPointsPosition.Count == 0)
        {
            GetWayPoints();
        }

        float distance = Vector3.Distance(transform.position, _wayPointsPosition[_currentTime]);
        while (distance > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPointsPosition[_currentTime], Time.deltaTime);
            distance = Vector3.Distance(transform.position, _wayPointsPosition[_currentTime]);
            yield return null;
        }

        if (_currentTime < _wayPointsPosition.Count -1)
        {
            _currentTime++;
            StartCoroutine(MoveToNextWayPoint());
        }
    }
}