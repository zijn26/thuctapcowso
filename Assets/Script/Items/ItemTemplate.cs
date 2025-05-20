using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    [SerializeField] public Item itemData;
    [SerializeField] protected SpriteRenderer iconObj;
    [SerializeField] protected BoxCollider2D boxColider;
    [SerializeField] protected Rigidbody2D rigid;
    [SerializeField] public int quanity = 1;
    protected void OnEnable()
    {
        this.ResetState();
        this.quanity = 1;
        this.rigid.bodyType = RigidbodyType2D.Dynamic;
    }
    protected void Awake()
    {
        this.ResetState();
    }
    public void UploadDataForTemplate(Item item)
    {
        if (item == null || iconObj == null)
        {
            Debug.LogWarning("UploadDataForTemplate : item not found");
        }
        itemData = item;// neu la tham chieu khi tao nhieu item giong nhau se co the bi bug.
        if (iconObj.sprite == null)
        {
            iconObj.sprite = item.iconIt;
        }
        boxColider.size = iconObj.size;
        this.gameObject.name = item.name;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            rigid.bodyType = RigidbodyType2D.Static;
            // Debug.Log("va");
        }
        // else Debug.Log(col.gameObject.name);
    }
    protected void ResetState()
    { 
        if (iconObj == null) iconObj = this.transform.GetComponent<SpriteRenderer>();
        if (boxColider == null) boxColider = this.transform.GetComponent<BoxCollider2D>();
        if (rigid == null) rigid = this.transform.GetComponent<Rigidbody2D>();
    }
}
