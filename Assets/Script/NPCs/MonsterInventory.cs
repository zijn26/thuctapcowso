using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterInventory: MonoBehaviour
{
    [SerializeField] protected List<ItemDropMonster> listDrop;
    [SerializeField] protected float forceSlide;
    [Serializable]
    public class ItemDropMonster
    {
        public Item item;
        public int quanity;
        public float chanceDrop;
    }
    public void DropItem()
    {
        ItemTemplate itemTemplate;
        Transform transform;
        listDrop.ForEach(item => {
            if(UnityEngine.Random.Range(0 , 1f) < item.chanceDrop )
            {
                transform = ItemPool.Instance.SpawnItem(item.item.idItem, this.transform.position);
                itemTemplate = transform.GetComponent<ItemTemplate>();
                itemTemplate.quanity = UnityEngine.Random.Range(1, item.quanity);
                ItemSlide(transform);
            }
        });
    }
    protected void ItemSlide(Transform item)
    {
        Vector2 dirSlide = new Vector2(UnityEngine.Random.Range(0 , 1f) , UnityEngine.Random.Range(0 , 1f));
        item.GetComponentInParent<Rigidbody2D>().AddForce(dirSlide * forceSlide , ForceMode2D.Impulse);
    }
}
