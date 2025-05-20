using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCrl : HungMono
{
    public static PlayerCrl Instance;
    public ProceserPlayer proceserPlayer;
    public InventoryPlayer invetory;
    public EquipmentSystem equipmentSystem;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // proceserPlayer.leveManager.AddExperence(10);
            // proceserPlayer.statSys.AddBonusStat(StatType.Attack, 10);
              invetory.AddItem(ItemDataMana.Instance.GetDataItem(1), 3);

        // invetory.AddItem(ItemDataMana.Instance.GetDataItem(2), 3);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            equipmentSystem.EquipItem(invetory.listItem[0].itemData);
            // proceserPlayer.combatPlayer.TakeDamage(10);
            // BarCrl.Instance.SetValueHpBar(proceserPlayer.statSys.GetStatNumber(StatType.Hp));

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            // equipmentSystem.EquipItem(invetory.listItem[1].itemData);
            equipmentSystem.UnEquipItem(equipmentSystem.listEquipment[ItemType.Weopon]);

            // proceserPlayer.statSys.AddBaseStat(StatType.Hp, 10);
        }
    }
    protected override void LoadComponent()
    {
        Debug.Log("Done Load Player Crl");
        LoadProceserPlayer();
        LoadInventory();
        LoadEquipmentSystem();
        equipmentSystem.OnEquipItemChanged += HandleEquipItemChanged;
        equipmentSystem.OnUnEquipItemChanged += HandleEquipItemChanged;
    }
    protected void LoadProceserPlayer()
    {
        if (proceserPlayer == null)
        {
            this.proceserPlayer = this.transform.GetComponentInChildren<ProceserPlayer>();
        }
    }
    protected void LoadInventory()
    {
        if (invetory == null)
        {
            this.invetory = this.transform.GetComponentInChildren<InventoryPlayer>();
        }
    }
    protected void LoadEquipmentSystem()
    {
        if (equipmentSystem == null)
        {
            this.equipmentSystem = this.transform.GetComponentInChildren<EquipmentSystem>();
        }
    }
    
    protected void HandleEquipItemChanged(object sender, System.EventArgs e)
    {
        var (itemold, itemequip) = ((Item, Item))sender;
        if (itemold != null) invetory.AddItem(itemold, 1);
        if (itemequip != null) invetory.RemoveItem(itemequip, 1);
    }
    // protected void LoadInfoToBar()
    // {
    //     // BarCrl.Instance.SetValueHpBar(proceserPlayer.statSys.GetStatNumber(StatType.Hp));
    //     // BarCrl.Instance.SetSaitamaBar(proceserPlayer.statSys.GetStatNumber(StatType.Saitama));
    //     // BarCrl.Instance.SetExperentceBar(proceserPlayer.leveManager.ValueExpBar());
    // }
    // protected void LoadLeveManager()
    // {
    //     if(leveManager == null )
    //     {
    //         this.leveManager = this.transform.GetComponentInChildren<LeveManager>();
    //     }
    // }

    // nhặt item khi va chạm với item 
    protected void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        ItemTemplate itemTemplate = col.gameObject.GetComponent<ItemTemplate>();
        if (itemTemplate == null) return;
        // Debug.Log("have item template");
        invetory.AddItem(itemTemplate.itemData, itemTemplate.quanity);
        ItemPool.Instance.DeSpawnObj(col.gameObject.transform);
    }

}
