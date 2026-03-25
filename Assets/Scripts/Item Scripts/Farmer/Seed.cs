using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "New Seed/Seed")]
public class Seed : InventoryItemData
{
    [Header("Seed Growth Settings")]
    public int DaysToGrow;
    public Sprite[] GrowthSprites;
    public Sprite[] GrowthWetSprites;

    [Header("Harvest Result")]
    public InventoryItemData CropToYield;

    public int MinYield = 1;
    public int MaxYield = 1;
}
