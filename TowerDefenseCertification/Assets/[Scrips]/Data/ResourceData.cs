using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/CreateResourceData")]

public class ResourceData : ScriptableObject
{
    [Serializable]
    public struct WeaponConfig
    {
        public string WeaponName;
        public int WeaponCost;
    }

    public WeaponConfig[] WeaponsCosts;
}