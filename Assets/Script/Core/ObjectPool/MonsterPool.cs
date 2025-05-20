using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterPool : Objectpool
{
    protected static MonsterPool intance;
    public static MonsterPool Instance => intance;
    void Awake()
    {
        if(intance == null )
        {
            intance = this;
        }else Destroy(gameObject);
    }
    protected override void LoadComponent()
    {
    }

    protected void Update()
   {
        // if(Input.GetKeyDown(KeyCode.I))
        // {
        //     ItemPool.Instance.SpawnItem(1 , transform.position);
        // }
        // if(Input.GetKeyDown(KeyCode.U))
        // {
        //     ItemPool.Instance.SpawnItem(2 , transform.position);
        // }

        // if(Input.GetKeyDown(KeyCode.U))
        // {
        //     DeSpawnObj(testObj);
        // }
   }
}
