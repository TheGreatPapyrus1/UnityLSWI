using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyLabel : MonoBehaviour
{

    public TextMeshProUGUI label;

    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();   
    }

    void Update()
    {
        label.text = "$" + FindObjectOfType<Player>().GetDollars().ToString();
    }
}
