using UnityEngine;

public class InventoryDebugAdder : MonoBehaviour
{
    [SerializeField] private ItemData testItem;

    public void AddTestItem()
    {
        if (Inventory.Instance != null && testItem != null)
        {
            Inventory.Instance.AddItem(testItem, 1);
            Debug.Log("Item ajouté : " + testItem.name);
        }
    }
}

