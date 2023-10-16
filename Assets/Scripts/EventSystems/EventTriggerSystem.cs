using System;

public class EventTriggerSystem : Singleton<EventTriggerSystem>
{
    public event Action<string> onTriggerItemSelctor;
    public void TriggerItemSelector(string itemName)
    {
        if (onTriggerItemSelctor != null)
        {
            onTriggerItemSelctor(itemName);
        }
    }

    public event Action<string, float, bool> onTriggerEquippedItemOnOrOff;
    public void TriggerEquippedItemOnOrOff(string name, float amount, bool isOnOrOff)
    {
        if (onTriggerEquippedItemOnOrOff != null)
        {
            onTriggerEquippedItemOnOrOff(name, amount, isOnOrOff);
        }
    }

    public event Action ontriggerUseItem;
    public void TriggerUseItem()
    {
        if (ontriggerUseItem != null)
        {
            ontriggerUseItem();
        }
    }
}