using System;
using UnityEngine;


public enum ItemType { Generic, Shovel, WateringCan, Axe, Seed }

public enum ItemEquipmentType
{
	None,       // Para itens comuns como madeira, maçã
	Head,
	Chest,
	Legs,
	Feet,
	RightHand,
	LeftHand
}

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
	public String ID;
	public string DisplayName;
	[TextArea(4, 4)] public string Description;
	public Sprite Icon;
	public int MaxStackSize;
	public int Price;
	public GameObject ItemPrefab;
	public bool CanSold;
	public ItemType Type;
	public ItemEquipmentType EquipmentType;

	private void OnValidate()
	{
		if (string.IsNullOrEmpty(ID))
		{
			ID = Guid.NewGuid().ToString();

#if UNITY_EDITOR
			UnityEditor.EditorUtility.SetDirty(this);
#endif
		}
	}
}
