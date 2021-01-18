using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;
    
    public enum NPCState
    {
        FirstDialogue,Missing,Finish
    }
    public NPCState state = NPCState.FirstDialogue;

    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "老公公")
        {
            playerInArea = true;
            StartCoroutine(Dialogue());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "老公公")
        {
            playerInArea = false;
            StopDialogue();
        }
    }
    private void StopDialogue()
    {
        dialogue.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator Dialogue()
    {
        dialogue.SetActive(true);
        textContent.text = "";
        textName.text = name;

        string dialogueString = data.dialogueB;

        switch (state)
        {
            case NPCState.FirstDialogue:
                dialogueString = data.dialogueA;
                break;
            case NPCState.Missing:
                dialogueString = data.dialogueB;
                break;
            case NPCState.Finish:
                dialogueString = data.dialogueC;
                break;
        }

        for (int i = 0; i < dialogueString.Length; i++)
        {
            textContent.text += dialogueString[i] + "";
            yield return new WaitForSeconds(interval);
        } 
      
    }
}
