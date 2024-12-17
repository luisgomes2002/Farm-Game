using System;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	private ItemPickUp currentItem;

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
		DetectItemUnderMouse();
		OnClickItem();
	}

	public ItemPickUp OnClickItem()
	{
		if (currentItem != null && Input.GetMouseButtonDown(0))
		{
			ItemPickUp itemToReturn = currentItem;
			Debug.Log("Click");
			currentItem = null;
			return itemToReturn;
		}

		return null;
	}

	private void DetectItemUnderMouse()
	{
		Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

		if (hit.collider != null)
		{
			ItemPickUp item = hit.collider.GetComponent<ItemPickUp>();
			if (item != null && currentItem != item)
			{
				currentItem = item;
			}
		}
	}
}