using System.Collections.Generic;
using UnityEngine;

public enum InventoryDataType { Hotbar, Bag }

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventoryDataType inventoryType;
    [SerializeField] private InventorySlot_UI[] slots;

    protected override void Start()
    {
        base.Start();

        if (inventoryHolder != null)
        {
            inventorySystem = inventoryType == InventoryDataType.Hotbar
                ? inventoryHolder.HotbarSystem
                : inventoryHolder.BagSystem;

            inventorySystem.OnInventorySlotsChanged += UpdateSlot;
        }
        else Debug.LogWarning($"No inventory assigned to {this.gameObject}");

        AssignSlot(InventorySystem);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (slots.Length != invToDisplay.InventorySize)
        {
            Debug.LogWarning($"ATENÇÃO: Tamanho dessincronizado no {gameObject.name}! A UI tem {slots.Length} espaços, mas o InventoryHolder configurou {invToDisplay.InventorySize} espaços.");
        }

        for (int i = 0; i < inventorySystem.InventorySize; i++)
        {
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }
}
