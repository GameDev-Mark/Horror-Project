using System;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemSelector : MonoBehaviour
{
    public float distanceChecker = 3f; // modified in inspector
    public float outlineWidth = 4f; // modified in inspector

    // PRIVATE FIELDS //
    private bool isHittingItem;

    private RaycastHit hit;
    private RaycastHit lastHit;

    // Update is called once per frame
    void Update()
    {
        ItemSelecting();
    }

    //
    private void ItemSelecting()
    {
        if (isHittingItem) // not looking at anything
        {
            if (!Physics.Raycast(transform.position, transform.forward, out hit, distanceChecker) || hit.collider != lastHit.collider)
            {
                isHittingItem = false;

                CheckOutlineComponent(null, 0f);

                EventTriggerSystem.Instance.TriggerItemSelector(string.Empty);

                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceChecker, Color.white);

            }
        }
        else // looking at an item
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanceChecker) && hit.transform.GetComponent<Outline>())
            {
                isHittingItem = true;
                lastHit = hit;

                CheckOutlineComponent(hit.collider.gameObject, outlineWidth);

                EventTriggerSystem.Instance.TriggerItemSelector(hit.collider.gameObject.name);

                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceChecker, Color.yellow);
            }
        }
    }

    //
    private void CheckOutlineComponent(GameObject item, float outlineWidth)
    {
        try
        {
            item.GetComponent<Outline>().OutlineWidth = outlineWidth;
        }
        catch (NullReferenceException)
        {
           FindObjectOfType<Outline>().OutlineWidth = 0;
        }
    }
}