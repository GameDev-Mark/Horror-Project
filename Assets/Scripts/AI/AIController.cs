using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //
    public void DestroyThisEnemy()
    {
        Destroy(this.gameObject);
    }
}