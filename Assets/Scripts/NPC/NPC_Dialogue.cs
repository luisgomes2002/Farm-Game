using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float DialogueRange;
    public LayerMask PlayerLayer;
    public DialogueSettings Dialogue;

    private bool playerHit;

    private List<string> sentences = new List<string>();

    void Start()
    {
        GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());
        }
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < Dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.languege)
            {
                case DialogueControl.Idiom.pt:
                    sentences.Add(Dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.Idiom.en:
                    sentences.Add(Dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.Idiom.jp:
                    sentences.Add(Dialogue.dialogues[i].sentence.japanese);
                    break;

                case DialogueControl.Idiom.kr:
                    sentences.Add(Dialogue.dialogues[i].sentence.korean);
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogueRange, PlayerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DialogueRange);
    }
}
