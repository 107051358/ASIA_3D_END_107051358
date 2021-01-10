using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData date;

    public bool playerInArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "小明")
        {
            playerInArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "小明")
        {
            playerInArea = false;
        }
    }
}
