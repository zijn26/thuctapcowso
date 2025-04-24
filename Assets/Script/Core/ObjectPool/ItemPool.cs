using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : Objectpool
{
    protected static ItemPool intance;
    public static ItemPool Instance => intance;
    void Awake()
    {
        if(intance == null)
        {
            intance = this;
        }else{
            Destroy(gameObject);
        }
    }
    [SerializeField] protected GameObject prefabTemplate;
    protected override void LoadComponent()
    {
    }
    public Transform SpawnItem(int IdItem , Vector3 spawnPos)
    {
        // prefabTemplate.transform.GetComponent<ItemTemplate>().UploadDataForTemplate(ItemDataMana.Instance.GetDataItem(IdItem));
        Transform item = SpawnObj(prefabTemplate.transform , spawnPos);
        ItemTemplate itemTemplate = item.GetComponent<ItemTemplate>();
        itemTemplate.UploadDataForTemplate(ItemDataMana.Instance.GetDataItem(IdItem));
        return item.transform;
    }
    public Transform SpawnItem(Item itemSpawn , Vector3 spawnPos)
    {
        Transform item = SpawnObj(prefabTemplate.transform , spawnPos);
        ItemTemplate itemTemplate = item.GetComponent<ItemTemplate>();
        itemTemplate.UploadDataForTemplate(ItemDataMana.Instance.GetDataItem(itemSpawn.idItem));
        return item.transform;
    }
    protected override bool ConditionPool(Transform objInList, Transform obj)
    {
        return !objInList.gameObject.activeSelf;
    }
}
