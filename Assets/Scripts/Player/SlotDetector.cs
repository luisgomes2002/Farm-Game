using UnityEngine;

public class SlotDetector : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Slot currentSlot;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.LogError("Câmera principal não encontrada!");
            }
        }
    }

    private void Update()
    {
        DetectSlotUnderMouse();
        OnClickSlot();
    }

    public Slot OnClickSlot()
    {
        if (currentSlot != null && Input.GetMouseButtonDown(0))
        {
            return currentSlot;
        }

        return null;
    }

    private void DetectSlotUnderMouse()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Slot slot = hit.collider.GetComponent<Slot>();
            if (slot != null && currentSlot != slot)
            {
                currentSlot = slot;
            }
        }
        else
        {
            currentSlot = null;
        }
    }
}
