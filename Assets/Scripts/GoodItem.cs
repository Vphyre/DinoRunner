using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem : ItemBase
{
    // Start is called before the first frame update
    void Start()
    {
        itemName = "GoodItem";
    }

    // Update is called once per frame
    void Update()
    {
        getItem = Physics2D.CircleCast(transform.position, itemArea, transform.position, itemArea, playerLayer);
        GetItem();
    }

    protected void GetItem()
    {
        if(getItem)
        {
            Heal();
            DestroyItem();
        }
    }
   

    
}
