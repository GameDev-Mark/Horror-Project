using TMPro;
using UnityEngine;

public class UI_Handler : MonoBehaviour
{
    public TMP_Text itemSelectedName;
    public TMP_Text percentageText;
    public TMP_Text currentlyEquippedText;

    // Start is called before the first frame update
    void Start()
    {
        NoCurrentItemEquipped();
        NotCurrentlySelectingAnyItem();

        EventTriggerSystem.Instance.onTriggerItemSelctor += ItemSelecting;
        EventTriggerSystem.Instance.onTriggerEquippedItemOnOrOff += CheckIfItemIsOnOrOff;
    }

    //
    private void ItemSelecting(string itemName)
    {
        // name of gameobject on screen when hovering over OR maybe selecting ?
        itemSelectedName.text = itemName.ToString();
    }

    // event trigger apply text according to if an item is on OR off
    private void CheckIfItemIsOnOrOff(string name, float amount, bool _isObjectOnOrOff)
    {
        if (_isObjectOnOrOff)
        {
            currentlyEquippedText.text = name;
            percentageText.text = Mathf.Round(amount) + "%";

            percentageText.CrossFadeAlpha(1f, 0.2f, false);
            currentlyEquippedText.CrossFadeAlpha(1f, 0.2f, false);
        }
        else
        {
            percentageText.CrossFadeAlpha(0.1f, 0.2f, false);
            currentlyEquippedText.CrossFadeAlpha(0.1f, 0.2f, false);
        }
    }

    // void at start() if no item is currently equipped
    private void NoCurrentItemEquipped()
    {
        currentlyEquippedText.text = string.Empty;
        percentageText.text = string.Empty;
    }

    // void at start() if not selecting anything
    private void NotCurrentlySelectingAnyItem()
    {
        itemSelectedName.text = string.Empty;
    }
}