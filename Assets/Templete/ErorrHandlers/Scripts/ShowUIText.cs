﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUIText : MonoBehaviour
{
    [SerializeField] StringVariable textToShow;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = textToShow.Value;
    }

}
