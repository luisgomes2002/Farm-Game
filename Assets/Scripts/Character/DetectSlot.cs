using UnityEngine;

public class DetectSlot : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        character.DetectedSlots.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, character.InteractionRange, character.SlotLayer);

        foreach (Collider2D hit in hits)
        {
            Slot slot = hit.GetComponent<Slot>();
            if (slot != null)
            {
                character.DetectedSlots.Add(slot);
            }
        }
    }

}
