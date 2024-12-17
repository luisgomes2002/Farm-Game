using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "New Seed/Seed")]
public class Seed : ScriptableObject
{
    [Header("Image")]
    public Sprite SeedPacket;
    public Sprite SeedSprite;
    public Sprite WetSeedSprite;

    [Header("Settings")]
    public string SeedName;
    public string SeedRarity;

    public int SeedAmount;
    public int SeedMaxAmount;
    public int Price;
    public int DaysToGrow;
}
