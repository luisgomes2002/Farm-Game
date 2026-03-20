using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string japanese;
    public string korean;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuildEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings dialogueSettings = (DialogueSettings)target;

        Languages language = new Languages();
        language.portuguese = dialogueSettings.sentence;

        Sentences sentence = new Sentences();
        sentence.profile = dialogueSettings.speakerSprite;
        sentence.sentence = language;

        if (GUILayout.Button("Create Dialogue"))
        {
            if (dialogueSettings.sentence != "")
            {
                dialogueSettings.dialogues.Add(sentence);

                dialogueSettings.speakerSprite = null;
                dialogueSettings.sentence = "";
            }
        }
    }
}
#endif