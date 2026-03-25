using UnityEngine;
using System.Collections.Generic;

public class PlayerSetDisplay : InventoryDisplay
{
    [Header("Referência Lógica")]
    [SerializeField] private PlayerSet playerSet;

    [Header("Slots de UI")]
    [SerializeField] private InventorySlot_UI headUI;
    [SerializeField] private InventorySlot_UI chestUI;
    [SerializeField] private InventorySlot_UI legUI;
    [SerializeField] private InventorySlot_UI footUI;
    [SerializeField] private InventorySlot_UI rightHandUI;
    [SerializeField] private InventorySlot_UI leftHandUI;

    protected override void Start()
    {
        base.Start();

        AssignSlot(null);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        AssignSpecificSlot(headUI, playerSet.HeadSlot, ItemEquipmentType.Head);
        AssignSpecificSlot(chestUI, playerSet.ChestSlot, ItemEquipmentType.Chest);
        AssignSpecificSlot(legUI, playerSet.LegSlot, ItemEquipmentType.Legs);
        AssignSpecificSlot(footUI, playerSet.FootSlot, ItemEquipmentType.Feet);
        AssignSpecificSlot(rightHandUI, playerSet.RightHand, ItemEquipmentType.RightHand);
        AssignSpecificSlot(leftHandUI, playerSet.LeftHand, ItemEquipmentType.LeftHand);
    }

    private void AssignSpecificSlot(InventorySlot_UI uiSlot, InventorySlot logicSlot, ItemEquipmentType acceptedType)
    {
        if (uiSlot == null || logicSlot == null) return;

        uiSlot.AcceptableType = acceptedType;

        slotDictionary.Add(uiSlot, logicSlot);
        uiSlot.Init(logicSlot);
    }
}
