using UnityEngine;

public class TorchLightController : EquippedItemHandler
{
    private Light torchLight;

    private float percentage;

    private bool isCurrentlyEquipped;

    // Start is called before the first frame update
    void Start()
    {
        torchLight = GetComponentInChildren<Light>();
        isCurrentlyEquipped = torchLight.gameObject.activeInHierarchy;
        EventTriggerSystem.Instance.onTriggerEquippedItemOnOrOff += ObjectFuncComposition;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Make a new hierarchy script controlling items such as torch , gun?, etc ?????
        ItemEquipped(gameObject.name, percentage, isCurrentlyEquipped);
    }

    //
    protected override void ObjectFuncComposition(string name, float amount, bool _isOnOrOff)
    {
        //GameObjectName(name);
        ControllingAmount(amount);
        OnOrOff(_isOnOrOff);
    }

    //
    protected override void GameObjectName(string name)
    {
        name = gameObject.name;
    }

    //
    protected override void ControllingAmount(float amount)
    {
        if (torchLight.gameObject.activeInHierarchy)
        {
            torchLight.range -= Time.deltaTime / 50f;

            percentage = (torchLight.range / 20f) * 100;
            amount = percentage;
        }
    }

    //
    protected override void OnOrOff(bool isOnOrOff)
    {
        if (base.TurnOnOrOffItem(false))
        {
            if (torchLight.gameObject.activeInHierarchy)
            {
                torchLight.gameObject.SetActive(false);
            }
            else
            {
                torchLight.gameObject.SetActive(true);
            }
            isCurrentlyEquipped = torchLight.gameObject.activeInHierarchy;
            isOnOrOff = isCurrentlyEquipped;
        }
    }
}