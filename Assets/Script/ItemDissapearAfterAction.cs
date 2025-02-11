using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDissapearAfterAction : MonoBehaviour
{


    public GameObject item;
    public GameObject boss;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;


    void Start()
    {

    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }

            }

        if (!boss.activeSelf)
        {
            item.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }

    }

}