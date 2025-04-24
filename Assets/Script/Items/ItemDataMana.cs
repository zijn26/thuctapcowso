using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataMana : HungMono
{
    protected static ItemDataMana instance;
    public static ItemDataMana Instance => instance;
    [SerializeField]public Dictionary<int , Item> listDataIt;

    protected override void LoadComponent()
    {
    }

    void Awake()
    {
        if(instance == null )
        {
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    protected override void Start()
    {
        base.Start();
        if(listDataIt == null)
        {
            listDataIt = new ();
        }
    }
    protected Item GetDataItemFormSC(int idItem)
    {
        Item item = Resources.Load<Item>("ID" + idItem.ToString());
        if(item != null)
            return item;
        else return null;
    }
    public Item GetDataItem(int idItem)
    {
        if(!listDataIt.ContainsKey(idItem))
        {
            Item item = GetDataItemFormSC(idItem);
            if( item == null) 
            {
                Debug.LogWarning("Don't Found Item In SC");
                return null;
            }
            listDataIt.Add(idItem , item);
            return item;
        }
        return listDataIt[idItem];
    }
}
