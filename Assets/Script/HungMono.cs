using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HungMono : MonoBehaviour
{
    protected virtual void Start()
    {
        this.LoadComponent();
    }
    protected virtual void Reset()
    {
        this.LoadComponent();
    }
    protected abstract void LoadComponent();
}
