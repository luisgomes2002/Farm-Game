using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    public InventoryItemData ItemData;
    public float MoveSpeed;
    public float MoveDistance;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * MoveSpeed) * MoveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            GetItem(player);
        }
    }

    public void GetItem(Player player)
    {
        var inventory = player.transform.GetComponent<InventoryHolder>();

        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            Destroy(this.gameObject);
        }
    }
}
