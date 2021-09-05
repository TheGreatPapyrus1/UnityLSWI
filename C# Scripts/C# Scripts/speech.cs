using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class speech : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] int currentIndex = 0;

    [SerializeField] GameObject bigSelf;
    [SerializeField] GameObject interactOption;

    [Header("Text to prompt the player to interact")]
    [SerializeField] string interactionText;

    [SerializeField] GameObject parentOfBigShopkeeper;

    bool isStandingBy = false;

    bool inShop = false;
    int numberOfSpeechOptions;

    [SerializeField] List<string> speechOptions = new List<string>();

    private void Start()
    {
        numberOfSpeechOptions = speechOptions.Count;
    }

    public void UpdateText()
    {
        string currentSpeechOption;
        if (!inShop)
        {
            if (currentIndex < numberOfSpeechOptions)
            {
                currentSpeechOption = speechOptions[currentIndex];
                
                parentOfBigShopkeeper.SetActive(true);
                interactOption.SetActive(false);
                text.text = currentSpeechOption;


                currentIndex++;
            }
            else
            {
                StartShop();
            }
        }

        
    }

    public void Standby()
    {
        if (!isStandingBy)
        {
            isStandingBy = true;
            interactOption.gameObject.SetActive(true);
            interactOption.GetComponentInChildren<TextMeshProUGUI>().text
                = interactionText;
        }
    }

    public void Idle()
    {
        isStandingBy = false;
        interactOption.gameObject.SetActive(false);

        parentOfBigShopkeeper.SetActive(false);
    }


    public void StartShop()
    {
        Idle();
        GetComponent<Shop>().ConstructShopMenu();
        FindObjectOfType<Player>().SetInMenu(true);
    }

}
