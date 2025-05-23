using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{

    //public GameObject player;
    //public GameObject AAA;
    public GameObject dialoguePanel; 
    public GameObject info;
    public GameObject pressTheKeyInfo;
    public GameObject dialogueText;
    public GameObject contButton;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    private bool playerIsClose;
    private bool playerPressTheButton;

    public RectTransform uiElement;
    //private bool isClose;
    //private GameObject Npc;

    
    // Update is called once per frame
    void Update()
    {
        if (playerIsClose)
        {
            //InfoCome();
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressTheKeyInfo.SetActive(false);
                info.SetActive(true);
                if (dialoguePanel.activeInHierarchy)
                {
                    ZeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                }


            }

            if (dialogueText.GetComponent<TextMeshProUGUI>().text == dialogue[index])
            {
                contButton.SetActive(true);
            }
        }
        else
        {
           //InfoGone();
            return;
        }

    }
    public void NextLine()
    {
        contButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.GetComponent<TextMeshProUGUI>().text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText();
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void ZeroText()
    {
        dialogueText.GetComponent<TextMeshProUGUI>().text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        ////info.SetActive(false);
        //pressTheKeyInfo.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            //uiElement.anchoredPosition = new Vector2(collision.gameObject.transform.position.x,collision.gameObject.transform.position.y + 0.5f);
            playerIsClose = true;
            pressTheKeyInfo.SetActive(true);
            //AAA.SetActive(true);
            //isClose = true;
            //print("npc is in your area");
            //FindObjectOfType<NPC>().GetNpc(collision.gameObject,isClose);
            //GameObject Npc = collision.gameObject.GetComponent<GameObject>();
            //uiElement.anchoredPosition = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y + 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("npc"))
        {
            //AAA.SetActive(false);
            uiElement.anchoredPosition = new Vector2(0,0);
            playerIsClose = false;
            //playerPressTheButton = false;
            //playerPressTheButton = !playerPressTheButton;
            pressTheKeyInfo.SetActive(false);
            info.SetActive(false);
            ZeroText();
            //print("npc is in your area");
        }
    }

}
