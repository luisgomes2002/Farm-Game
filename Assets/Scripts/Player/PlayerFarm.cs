using UnityEngine;

public class PlayerFarm : MonoBehaviour
{
    private Player player;
    private PlayerSet playerSet;
    private SlotDetector slotDetector;
    private Animator anim;
    private Slot currentSlotToDig;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerSet = GetComponent<PlayerSet>();
        slotDetector = GetComponent<SlotDetector>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // OnDig();
        // OnWatering();
        // OnCutting();
    }

    // private void OnDig()
    // {
    //     if (playerSet.RightHand.CompareTag("Shovel") && player.CanClick)
    //     {
    //         if (Input.GetMouseButton(0))
    //         {
    //             Slot clickedSlot = slotDetector.OnClickSlot();

    //             if (clickedSlot != null && player.DetectedSlots.Contains(clickedSlot))
    //             {
    //                 player.CanMove = false;
    //                 player.CanClick = false;
    //                 anim.SetTrigger("isDigging");
    //                 currentSlotToDig = clickedSlot;
    //             }
    //         }
    //     }
    // }

    // private void OnWatering()
    // {
    //     if (playerSet.RightHand.CompareTag("WateringCan") && player.CanClick)
    //     {
    //         if (Input.GetMouseButton(0)) // && playerItems.CurrentWater > 0
    //         {
    //             Slot clickedSlot = slotDetector.OnClickSlot();

    //             if (clickedSlot != null && player.DetectedSlots.Contains(clickedSlot))
    //             {
    //                 player.CanMove = false;
    //                 player.CanClick = false;
    //                 anim.SetTrigger("isWatering");
    //                 currentSlotToDig = clickedSlot;
    //             }

    //         }
    //     }
    // }

    // private void OnCutting()
    // {
    //     if (playerSet.RightHand.CompareTag("Axe") && player.CanClick)
    //     {
    //         if (Input.GetMouseButton(0))
    //         {
    //             player.CanMove = false;
    //             player.CanClick = false;
    //             anim.SetTrigger("isCutting");
    //         }
    //     }
    // }

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
        player.CanMove = true;
        player.CanClick = true;
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
        player.CanMove = true;
        player.CanClick = true;
        anim.ResetTrigger("isWatering");
        anim.SetInteger("transition", 0);
    }

    private void StopCuttingAnimation()
    {
        player.CanMove = true;
        player.CanClick = true;
        anim.ResetTrigger("isCutting");
        anim.SetInteger("transition", 0);
    }

    #endregion
}
