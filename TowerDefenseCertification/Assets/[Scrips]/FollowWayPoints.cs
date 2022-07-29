using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] private string _pathName = default;
    [SerializeField] private List<Vector3> _wayPointsPosition = new List<Vector3>();
    [SerializeField] private float _distanceThreshold = 0.5f;
    [SerializeField] private float _WalkSpeed = default;
    [SerializeField] private GameState _gameState = default;
    private int _currentWayPoint = default;

    private void OnEnable()
    {
        _currentWayPoint = 0;
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

        float distance = Vector3.Distance(transform.position, _wayPointsPosition[_currentWayPoint]);
        while (distance > _distanceThreshold && _gameState.CurrentGameState == GameState.GameStateEnum.Playing)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPointsPosition[_currentWayPoint], Time.deltaTime * _WalkSpeed);
            distance = Vector3.Distance(transform.position, _wayPointsPosition[_currentWayPoint]);
            yield return null;
        }

        if (_currentWayPoint < _wayPointsPosition.Count -1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToNextWayPoint());
        }
    }
}