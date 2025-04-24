using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objectpool : HungMono
{
    [SerializeField]protected List<Transform> listPool = new();
    public Transform testObj;
    public Transform SpawnObj(Transform obj, Vector3 spawnPos)
    {
        Transform newObj = FindObjInList(obj);
        if(newObj == null)
        {
            newObj = Instantiate(obj);
            newObj.transform.SetParent(this.transform);
            newObj.name = obj.name;
        }
        newObj.gameObject.SetActive(true);
        newObj.position = spawnPos;
        
        listPool.Add(newObj);
        return newObj;
    }
    public void DeSpawnObj(Transform obj)
    {
        obj.gameObject.SetActive(false);
    }
    protected Transform FindObjInList(Transform obj)
    {
        Transform results;
        if(listPool.Count > 0 )
        {
            results = listPool.Find((x) => {
                if(this.ConditionPool(x , obj))
                    return true;
                else return false;
            });
            return results;
        }
        return null;
    }
    protected virtual bool ConditionPool(Transform objInList ,Transform obj)
    {
        return objInList.name == obj.name && objInList.gameObject.activeSelf == false;
    }

}
