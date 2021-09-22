using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public string itemName;
    public LayerMask playerLayer;
    protected bool getItem;
    public float itemArea;

    protected void Damage()
    {
        DinoController.life--;
    }
    protected void Heal()
    {
        DinoController.life++;;
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color  = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, itemArea);
    }
    protected void DestroyItem()
    {
        Destroy(gameObject);
    }
    
}
