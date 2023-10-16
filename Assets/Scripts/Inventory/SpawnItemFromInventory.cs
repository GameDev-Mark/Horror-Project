using System.Collections;
using UnityEngine;

public class SpawnItemFromInventory : MonoBehaviour
{
    GameObject handEquipItemPosition;
    private GameObject currentItemInHand;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        handEquipItemPosition = FindObjectOfType<EquippedItemPosition>().gameObject;
        inventoryManager = FindObjectOfType<InventoryManager>();

        EquippedItemEmptyGameObjectReference();

        StartCoroutine(PopuplateINventory());
    }

    private void Update()
    {
        InputHandlerSpawnItemToHand();
    }

    private void InputHandlerSpawnItemToHand()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            string item1 = inventoryManager.InventoryItems()[0];
            EnableOrDisableItemGameObject(item1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            string item2 = inventoryManager.InventoryItems()[1];
            EnableOrDisableItemGameObject(item2);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            string item3 = inventoryManager.InventoryItems()[2];
            EnableOrDisableItemGameObject(item3);
        }
    }

    private void EnableOrDisableItemGameObject(string itemName)
    {
        if (itemName != null && !currentItemInHand.name.Contains(itemName))
        {
            LoadAndSetGameObjectToHand(itemName);
        }
        else if (itemName != null && currentItemInHand.name.Contains(itemName))
        {
            currentItemInHand.name = "Hand";
            FindChildrenToEnableOrDisable(itemName, false);
        }
    }

    private void LoadAndSetGameObjectToHand(string itemName)
    {
        // if item already exists in inventory && if it the item gameobject is disabled.. Enable gameobject
        // ELSE instantiate item gameobject
        if (inventoryManager.InventoryItems().Contains(itemName) && !currentItemInHand.name.Contains(itemName))
        {
            currentItemInHand.name = itemName;
            FindChildrenToEnableOrDisable(itemName, true);
        }
        else
        {
            GameObject _item = Instantiate(Resources.Load($"Prefabs/{itemName}") as GameObject);
            _item.name = _item.name.Replace("(Clone)", "");
            _item.transform.position = handEquipItemPosition.transform.position;
            _item.transform.rotation = handEquipItemPosition.transform.rotation;
            _item.transform.parent = handEquipItemPosition.transform;
        }
    }

    private void FindChildrenToEnableOrDisable(string _itemName, bool onOrOff)
    {
        foreach (Transform item in handEquipItemPosition.transform)
        {
            item.gameObject.SetActive(false);

            if (item.gameObject.name.Contains(_itemName))
            {
                item.gameObject.SetActive(onOrOff);
            }
        }
    }

    private void EquippedItemEmptyGameObjectReference()
    {
        currentItemInHand = new GameObject();
        currentItemInHand.name = "Hand";
        currentItemInHand.transform.parent = transform;
    }



    // FAKE POPUPLATION TEST //
    private IEnumerator PopuplateINventory()
    {
        yield return new WaitForSeconds(1f);

        GameObject _item = Instantiate(Resources.Load($"Prefabs/{inventoryManager.InventoryItems()[0]}") as GameObject);
        _item.name = _item.name.Replace("(Clone)", "");
        _item.transform.position = handEquipItemPosition.transform.position;
        _item.transform.rotation = handEquipItemPosition.transform.rotation;
        _item.transform.parent = handEquipItemPosition.transform;

        _item.SetActive(false);

        GameObject _item2 = Instantiate(Resources.Load($"Prefabs/{inventoryManager.InventoryItems()[1]}") as GameObject);
        _item2.name = _item2.name.Replace("(Clone)", "");
        _item2.transform.position = handEquipItemPosition.transform.position;
        _item2.transform.rotation = handEquipItemPosition.transform.rotation;
        _item2.transform.parent = handEquipItemPosition.transform;

        _item2.SetActive(false);
    }
}