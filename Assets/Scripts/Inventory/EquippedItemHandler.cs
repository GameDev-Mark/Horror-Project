using UnityEngine;

public abstract class EquippedItemHandler : MonoBehaviour
{
    protected abstract void GameObjectName(string name);
    protected abstract void ControllingAmount(float amount);
    protected abstract void OnOrOff(bool isOnOrOff);
    protected abstract void ObjectFuncComposition(string name, float amount, bool _isOnOrOff);

    //
    protected virtual void ItemEquipped(string name, float percentage, bool isOnOrOff)
    {
        EventTriggerSystem.Instance.TriggerEquippedItemOnOrOff(name, percentage, isOnOrOff);
    }

    //
    protected virtual bool TurnOnOrOffItem(bool turnOnOrOff)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (turnOnOrOff)
            {
                turnOnOrOff = false;
            }
            else
            {
                turnOnOrOff = true;
            }
        }
        // TODO: remove constant update???
        return turnOnOrOff;
    }

    // Use item function ?? 
    protected virtual bool UseItem(bool canUseItem)
    {
        if (Input.GetMouseButtonDown(0))
        {
            canUseItem = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canUseItem = false;
        }

        return canUseItem;
    }
}