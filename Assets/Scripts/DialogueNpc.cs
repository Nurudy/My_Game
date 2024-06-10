using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueNpc : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (dialoguePanel.activeInHierarchy) //esto es para activar la cadena en la que esta el dialoguePanel.
            {
                ZeroText();
            }
            else
            {
                dialoguePanel.SetActive(true); //si se activa el panel del dialogo, a su vez se activa la funcion de las letras
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index]) //llamo al boton
        {
            contButton.SetActive(true);
        }
    }

    public void ZeroText() //activo el array y empieza siempre desde cero
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray()) //esto sirve para hacer una lista de letras, y que se vayan mostrando por separado
        {                                                     //como una cadena
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {

        contButton.SetActive(false); //así el jugador no skipea el texto hasta que no termine

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ZeroText() ;  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
}
