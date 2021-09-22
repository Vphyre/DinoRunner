using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    // Start is called before the first frame update
    void Start()
    {
        points.text = DinoController.life.ToString();
    }

}
