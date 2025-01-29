using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    //public GameObject dialoguePanel;
    ////public GameObject player;
    //public GameObject info;
    //public GameObject pressTheKeyInfo;
    //public Text dialogueText;
    //public GameObject contButton;
    //public string[] dialogue;
    //private int index;

    //public float wordSpeed;
    //public bool playerIsClose;
    //public bool playerPressTheButton;

    ////Transform npc;
    
    
    //public RectTransform uiElement;

    //private GameObject g;
    //private bool isCloseCheck;

    //public void GetNpc(GameObject gameObject,bool a)
    //{
    //    g = gameObject;
    //    isCloseCheck = a;


    //}


    //private void Start()
    //{
    //    //foreach (var item in dialogue)
    //    //{
    //    //    print(item);
    //    //}


    //    print(transform.localPosition);

    //    //print(npc.position.y);
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
    //    //{

    //    //    if (dialoguePanel.activeInHierarchy)
    //    //    {
    //    //        ZeroText();
    //    //    }
    //    //    else
    //    //    {
    //    //        dialoguePanel.SetActive(true);
    //    //        StartCoroutine(Typing());
    //    //    }
    //    //}
    //    //if (dialogueText.text == dialogue[index])
    //    //{
    //    //    contButton.SetActive(true);
    //    //}
    //    if (playerIsClose)
    //    {
    //        InfoComeOut();
    //    }
    //    else
    //    {
    //        //ZeroText();
    //        InfoGone();
    //    }
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        print("enter teh area after presskey");
    //        playerPressTheButton = true;
    //        if (playerPressTheButton)
    //        {
    //            InfoGone();
    //        }
    //        if (dialoguePanel.activeInHierarchy)
    //        {
    //            ZeroText();
    //        }
    //        else
    //        {
    //            dialoguePanel.SetActive(true);
    //            StartCoroutine(Typing());
    //        }

    //    }

    //    if (dialogueText.text == dialogue[index])
    //    {
    //        print("enter button true area");
    //        contButton.SetActive(true);
    //    }

    //}

    //public void InfoComeOut()
    //{
    //    info.SetActive(true);
    //    if (!playerPressTheButton)
    //        pressTheKeyInfo.SetActive(true);
    //    else
    //        pressTheKeyInfo.SetActive(false);

    //}
    //public void InfoGone()
    //{
    //    if (!playerIsClose)
    //        info.SetActive(false);

    //    pressTheKeyInfo.SetActive(false);
    //}

    //public void NextLine()
    //{

    //    contButton.SetActive(false);
    //    if (index < dialogue.Length - 1)
    //    {
    //        index++;
    //        dialogueText.text = "";
    //        StartCoroutine(Typing());
    //    }
    //    else
    //    {

    //        ZeroText();
    //    }
    //}

    //IEnumerator Typing()
    //{
    //    foreach (char letter in dialogue[index].ToCharArray())
    //    {
    //        dialogueText.text += letter;
    //        yield return new WaitForSeconds(wordSpeed);
    //    }
    //}
    //public void ZeroText()
    //{

    //    dialogueText.text = "";
    //    index = 0;
    //    dialoguePanel.SetActive(false);

    //    info.SetActive(false);
    //    pressTheKeyInfo.SetActive(false);

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        uiElement.anchoredPosition = new Vector2(transform.position.x,transform.position.y+0.5f);
    //        playerIsClose = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerIsClose = false;
    //        playerPressTheButton = false;
    //        ZeroText();
    //    }
    //}

}

//struct a
//{
    
//}
