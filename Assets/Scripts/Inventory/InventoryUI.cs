using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Transform gridParent;   // InventoryPanel
    [SerializeField] private ItemSlotUI slotPrefab;  // Prefab ItemSlot

    private readonly List<ItemSlotUI> spawnedSlots = new List<ItemSlotUI>();

    private void OnEnable()
    {
        if (Inventory.Instance != null)
        {
            Inventory.Instance.OnInventoryChanged += RefreshUI;
            RefreshUI();
        }
    }

    private void OnDisable()
    {
        if (Inventory.Instance != null)
        {
            Inventory.Instance.OnInventoryChanged -= RefreshUI;
        }
    }

    private void ClearSlots()
    {
        foreach (var slot in spawnedSlots)
        {
            if (slot != null)
                Destroy(slot.gameObject);
        }

        spawnedSlots.Clear();
    }

    public void RefreshUI()
    {
        if (Inventory.Instance == null)
        {
            Debug.LogWarning("InventoryUI: pas d'Inventory.Instance trouvé.");
            return;
        }

        ClearSlots();

        var slots = Inventory.Instance.Slots;
        foreach (var invSlot in slots)
        {
            var uiSlot = Instantiate(slotPrefab, gridParent);
            uiSlot.SetSlot(invSlot.item, invSlot.quantity);
            spawnedSlots.Add(uiSlot);
        }
    }
}

