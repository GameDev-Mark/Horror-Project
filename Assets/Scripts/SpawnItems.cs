using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    GameObject handEquipItemPosition;

    // Start is called before the first frame update
    void Start()
    {
        handEquipItemPosition = FindObjectOfType<EquippedItemPosition>().gameObject;
    }

    private void Update()
    {
        SpawnItemToHand();
    }

    //
    private void SpawnItemToHand()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject torchPrefab = Instantiate(Resources.Load("Prefabs/Torch") as GameObject);
            torchPrefab.transform.position = handEquipItemPosition.transform.position;
            torchPrefab.transform.parent = handEquipItemPosition.transform;
        }
    }
}