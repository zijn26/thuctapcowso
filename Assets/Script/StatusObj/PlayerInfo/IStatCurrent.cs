using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IStatCurrent 
{
    public Dictionary<StatType, float> curStat { get ; set; }
}
