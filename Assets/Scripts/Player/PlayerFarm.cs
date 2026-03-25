using System;
using UnityEngine;

public class PlayerFarm : MonoBehaviour
{
    private Character character;
    private PlayerSet playerSet;
    private SlotDetector slotDetector;
    private Animator anim;
    private Slot currentSlotToDig;

    private void Awake()
    {
        character = GetComponent<Character>();
        playerSet = GetComponent<PlayerSet>();
        slotDetector = GetComponent<SlotDetector>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        OnDig();
        OnWatering();
        OnCutting();
    }

    private void OnDig()
    {
        if (playerSet.RightHand.ItemData != null && playerSet.RightHand.ItemData.Type == ItemType.Shovel && character.CanClick)
        {
            if (Input.GetMouseButton(0))
            {
                Slot clickedSlot = slotDetector.OnClickSlot();

                if (clickedSlot != null && character.DetectedSlots.Contains(clickedSlot))
                {
                    character.CanMove = false;
                    character.CanClick = false;
                    anim.SetTrigger("isDigging");
                    currentSlotToDig = clickedSlot;
                }
            }
        }
    }

    private void OnWatering()
    {
        if (playerSet.RightHand.ItemData != null && playerSet.RightHand.ItemData.Type == ItemType.WateringCan && character.CanClick)
        {
            if (Input.GetMouseButton(0)) // && playerItems.CurrentWater > 0
            {
                Slot clickedSlot = slotDetector.OnClickSlot();

                if (clickedSlot != null && character.DetectedSlots.Contains(clickedSlot))
                {
                    character.CanMove = false;
                    character.CanClick = false;
                    anim.SetTrigger("isWatering");
                    currentSlotToDig = clickedSlot;
                }

            }
        }
    }

    private void OnCutting()
    {
        if (playerSet.RightHand.ItemData != null && playerSet.RightHand.ItemData.Type == ItemType.Axe && character.CanClick)
        {
            if (Input.GetMouseButton(0))
            {
                character.CanMove = false;
                character.CanClick = false;
                anim.SetTrigger("isCutting");
            }
        }
    }

    #region Actions
    private void OnDiggingAnimation()
    {
        if (currentSlotToDig != null)
        {
            currentSlotToDig.DigHole();
            currentSlotToDig = null;
        }
    }

    private void StopDiggingAnimation()
    {
        character.CanMove = true;
        character.CanClick = true;
        anim.ResetTrigger("isDigging");
        anim.SetInteger("transition", 0);
    }

    private void OnWateringAnimation()
    {
        if (currentSlotToDig != null)
        {
            currentSlotToDig.OnWet();
            currentSlotToDig = null;
        }
    }

    private void StopWateringAnimation()
    {
        character.CanMove = true;
        character.CanClick = true;
        anim.ResetTrigger("isWatering");
        anim.SetInteger("transition", 0);
    }

    private void StopCuttingAnimation()
    {
        character.CanMove = true;
        character.CanClick = true;
        anim.ResetTrigger("isCutting");
        anim.SetInteger("transition", 0);
    }

    #endregion
}
