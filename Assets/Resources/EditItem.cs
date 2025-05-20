// using UnityEditor;
// using UnityEngine;

// public class ItemEditor : EditorWindow
// {
//     private ItemData currentItem;
//     private ItemType selectedItemType;
//     private string savePath = "Assets/ScriptableObjects/Items";

//     [MenuItem("Tools/Item System/Item Editor")]
//     public static void ShowWindow()
//     {
//         GetWindow<ItemEditor>("Item Editor");
//     }

//     private void OnGUI()
//     {
//         GUILayout.Label("Create New Item", EditorStyles.boldLabel);

//         EditorGUILayout.Space();

//         selectedItemType = (ItemType)EditorGUILayout.EnumPopup("Item Type", selectedItemType);

//         if (GUILayout.Button("Create New Item"))
//         {
//             CreateNewItem();
//         }

//         EditorGUILayout.Space();
//         EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
//         EditorGUILayout.Space();

//         savePath = EditorGUILayout.TextField("Save Path", savePath);

//         if (currentItem != null)
//         {
//             EditorGUILayout.LabelField("Current Item", EditorStyles.boldLabel);
//             EditorGUI.BeginChangeCheck();

//             currentItem.itemName = EditorGUILayout.TextField("Item Name", currentItem.itemName);
//             currentItem.itemID = EditorGUILayout.TextField("Item ID", currentItem.itemID);
//             currentItem.itemDescription = EditorGUILayout.TextField("Description", currentItem.itemDescription);
//             currentItem.itemIcon = (Sprite)EditorGUILayout.ObjectField("Icon", currentItem.itemIcon, typeof(Sprite), false);
//             currentItem.rarity = (ItemRarity)EditorGUILayout.EnumPopup("Rarity", currentItem.rarity);
//             currentItem.isStackable = EditorGUILayout.Toggle("Stackable", currentItem.isStackable);

//             if (currentItem.isStackable)
//             {
//                 currentItem.maxStackSize = EditorGUILayout.IntField("Max Stack Size", currentItem.maxStackSize);
//             }

//             currentItem.weight = EditorGUILayout.FloatField("Weight", currentItem.weight);

//             // Hiển thị các trường cụ thể cho từng loại vật phẩm
//             if (currentItem is WeaponData weaponData)
//             {
//                 DrawWeaponFields(weaponData);
//             }
//             else if (currentItem is ArmorData armorData)
//             {
//                 DrawArmorFields(armorData);
//             }
//             else if (currentItem is ConsumableData consumableData)
//             {
//                 DrawConsumableFields(consumableData);
//             }

//             // Hiển thị chỉ số cơ bản
//             EditorGUILayout.LabelField("Base Stats", EditorStyles.boldLabel);
            
//             ItemStats stats = currentItem.baseStats;
//             stats.durability = EditorGUILayout.IntField("Durability", stats.durability);
//             stats.value = EditorGUILayout.IntField("Value", stats.value);

//             // Hiển thị thêm các stats phù hợp với loại vật phẩm
//             if (currentItem.itemType == ItemType.Weapon)
//             {
//                 stats.damage = EditorGUILayout.IntField("Damage", stats.damage);
//                 stats.attackSpeed = EditorGUILayout.FloatField("Attack Speed", stats.attackSpeed);
//                 stats.range = EditorGUILayout.FloatField("Range", stats.range);
//             }
//             else if (currentItem.itemType == ItemType.Armor)
//             {
//                 stats.defense = EditorGUILayout.IntField("Defense", stats.defense);
//                 stats.magicResistance = EditorGUILayout.IntField("Magic Resistance", stats.magicResistance);
//             }
//             else if (currentItem.itemType == ItemType.Consumable)
//             {
//                 stats.healthRestore = EditorGUILayout.IntField("Health Restore", stats.healthRestore);
//                 stats.manaRestore = EditorGUILayout.IntField("Mana Restore", stats.manaRestore);
//                 stats.buffDuration = EditorGUILayout.FloatField("Buff Duration", stats.buffDuration);
//             }

//             currentItem.baseStats = stats;

//             if (GUILayout.Button("Save Item"))
//             {
//                 SaveItem();
//             }
//         }
//     }

//     private void CreateNewItem()
//     {
//         switch (selectedItemType)
//         {
//             case ItemType.Weapon:
//                 currentItem = CreateInstance<WeaponData>();
//                 currentItem.itemType = ItemType.Weapon;
//                 break;
//             case ItemType.Armor:
//                 currentItem = CreateInstance<ArmorData>();
//                 currentItem.itemType = ItemType.Armor;
//                 break;
//             case ItemType.Consumable:
//                 currentItem = CreateInstance<ConsumableData>();
//                 currentItem.itemType = ItemType.Consumable;
//                 break;
//             default:
//                 currentItem = CreateInstance<ItemData>();
//                 currentItem.itemType = selectedItemType;
//                 break;
//         }

//         // Khởi tạo giá trị mặc định
//         currentItem.itemName = "New " + selectedItemType.ToString();
//         currentItem.itemID = System.Guid.NewGuid().ToString().Substring(0, 8);
//     }

//     private void DrawWeaponFields(WeaponData weapon)
//     {
//         EditorGUILayout.LabelField("Weapon Properties", EditorStyles.boldLabel);
//         weapon.weaponType = (WeaponType)EditorGUILayout.EnumPopup("Weapon Type", weapon.weaponType);
//         weapon.attackAnim = (AnimationClip)EditorGUILayout.ObjectField("Attack Animation", weapon.attackAnim, typeof(AnimationClip), false);
//         weapon.weaponPrefab = (GameObject)EditorGUILayout.ObjectField("Weapon Prefab", weapon.weaponPrefab, typeof(GameObject), false);
//         weapon.attackSound = (AudioClip)EditorGUILayout.ObjectField("Attack Sound", weapon.attackSound, typeof(AudioClip), false);
//         weapon.criticalChance = EditorGUILayout.Slider("Critical Chance", weapon.criticalChance, 0f, 1f);
//         weapon.criticalDamage = EditorGUILayout.FloatField("Critical Damage Multiplier", weapon.criticalDamage);
//         weapon.elementType = (ElementType)EditorGUILayout.EnumPopup("Element Type", weapon.elementType);
        
//         if (weapon.elementType != ElementType.None)
//         {
//             weapon.elementalDamage = EditorGUILayout.FloatField("Elemental Damage", weapon.elementalDamage);
//         }
//     }

//     private void DrawArmorFields(ArmorData armor)
//     {
//         EditorGUILayout.LabelField("Armor Properties", EditorStyles.boldLabel);
//         armor.armorType = (ArmorType)EditorGUILayout.EnumPopup("Armor Type", armor.armorType);
//         armor.armorPrefab = (GameObject)EditorGUILayout.ObjectField("Armor Prefab", armor.armorPrefab, typeof(GameObject), false);
//         armor.equipSlot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", armor.equipSlot);
//         armor.damageReduction = EditorGUILayout.Slider("Damage Reduction", armor.damageReduction, 0f, 1f);
//         armor.moveSpeedModifier = EditorGUILayout.FloatField("Move Speed Modifier", armor.moveSpeedModifier);
//     }

//     private void DrawConsumableFields(ConsumableData consumable)
//     {
//         EditorGUILayout.LabelField("Consumable Properties", EditorStyles.boldLabel);
//         consumable.consumableType = (ConsumableType)EditorGUILayout.EnumPopup("Consumable Type", consumable.consumableType);
//         consumable.cooldown = EditorGUILayout.FloatField("Cooldown", consumable.cooldown);
//         consumable.removeAfterUse = EditorGUILayout.Toggle("Remove After Use", consumable.removeAfterUse);
//         consumable.useEffect = (GameObject)EditorGUILayout.ObjectField("Use Effect", consumable.useEffect, typeof(GameObject), false);
//         consumable.useSound = (AudioClip)EditorGUILayout.ObjectField("Use Sound", consumable.useSound, typeof(AudioClip), false);
//     }

//     private void SaveItem()
//     {
//         if (currentItem == null) return;

//         // Đảm bảo thư mục tồn tại
//         if (!AssetDatabase.IsValidFolder(savePath))
//         {
//             string[] folders = savePath.Split('/');
//             string currentPath = folders[0];
//             for (int i = 1; i < folders.Length; i++)
//             {
//                 string folderPath = currentPath + "/" + folders[i];
//                 if (!AssetDatabase.IsValidFolder(folderPath))
//                 {
//                     AssetDatabase.CreateFolder(currentPath, folders[i]);
//                 }
//                 currentPath = folderPath;
//             }
//         }

//         // Tạo tên file
//         string fileName = currentItem.itemName.Replace(" ", "_");
//         string assetPath = $"{savePath}/{fileName}.asset";

//         // Lưu asset
//         AssetDatabase.CreateAsset(currentItem, assetPath);
//         AssetDatabase.SaveAssets();
//         AssetDatabase.Refresh();

//         EditorUtility.FocusProjectWindow();
//         Selection.activeObject = currentItem;
        
//         Debug.Log($"Đã lưu vật phẩm: {currentItem.itemName} tại {assetPath}");
//     }
// }