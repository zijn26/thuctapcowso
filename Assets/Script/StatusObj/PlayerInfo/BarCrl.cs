using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCrl : HungMono
{
    protected static BarCrl instance ;
    public static BarCrl Instance => instance;

    void Awake()
    {
        instance = this;
    }
    public Slider hpBar;
    public Slider staiBar;
    public Slider experenceBar;
    protected override void LoadComponent()
    {
        Debug.Log("Done load bar status");

        if(hpBar == null)
        {
            this.hpBar = this.transform.GetChild(0).GetComponent<Slider>();

        }
        if(staiBar == null)
        {
            this.staiBar = this.transform.GetChild(1).GetComponent<Slider>();
        }
        if(experenceBar == null)
        {
            this.experenceBar = this.transform.GetChild(2).GetComponent<Slider>();
        }
    }
    public void SetValueHpBar(float value)
    {
        this.hpBar.value = value;
    }
    public void SetSaitamaBar(float value)
    {
        this.staiBar.value = value;
    }
    public void SetExperentceBar(float value)
    {
        this.experenceBar.value = value;
    }
}
