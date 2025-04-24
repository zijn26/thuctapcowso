using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "MoveSC/MonsterAuto")]
public class MonsterAuto :ScriptableObject
{
    public float maxDistanceFromOriginPos;
    public float distanceToChaise;
    public float rangeStand; // is the distance to the monster to stop moving

}
