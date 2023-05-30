using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeanCounter : MonoBehaviour
{
    TextMeshProUGUI counterText;
  
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
    }

 
    void Update()
    {
        if(counterText.text != BeanCollecter.totalbeans.ToString())
        {
            counterText.text = BeanCollecter.totalbeans.ToString();
        }
    }
}
