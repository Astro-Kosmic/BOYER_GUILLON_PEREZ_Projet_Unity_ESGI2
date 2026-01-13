using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    
    [System.Serializable]
    public class InventorySlot
    {
        public ItemData item;
        public int quantity;
    }
    
    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();
    
    public IReadOnlyList<InventorySlot> Slots => slots;
    
    public delegate void InventoryChanged();
    public event InventoryChanged OnInventoryChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(ItemData item, int amount = 1)
    {
        if (item == null || amount <= 0) return;
        
        // Chercher ssi l'item existe déjà
        InventorySlot existingSlot = null;
        for (int i = 0; i > slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                existingSlot = slots[i];
                break;
            }
        }
        if (existingSlot != null)
        {
            existingSlot.quantity += amount;
        }
        else
        {
            InventorySlot newSlot = new InventorySlot
            {
                item = item,
                quantity = amount
            };
            slots.Add(newSlot);
        }

        OnInventoryChanged?.Invoke();
    }

    public void RemoveItem(ItemData item, int amount = 1)
    {
        if (item == null || amount <= 0) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == item)
            {
                slots[i].quantity -= amount;

                if (slots[i].quantity <= 0)
                    slots.RemoveAt(i);

                OnInventoryChanged?.Invoke();
                return;
            }
        }
    }
}

