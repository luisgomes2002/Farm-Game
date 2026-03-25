using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public InventoryItemData ItemData;
    // public float MoveSpeed;
    // public float MoveDistance;

    // private Vector3 startPosition;

    // void Start()
    // {
    //     startPosition = transform.position;
    // }

    // void Update()
    // {
    //     float newY = Mathf.Sin(Time.time * MoveSpeed) * MoveDistance;
    //     transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character != null)
        {
            GetItem(character);
        }
    }

    public void GetItem(Character character)
    {
        var inventory = character.transform.GetComponent<InventoryHolder>();

        if (!inventory) return;

        if (inventory.HotbarSystem.AddToInventory(ItemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
