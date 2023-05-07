using UnityEngine;

[CreateAssetMenu(fileName = "Convo", menuName = "ScriptableObjects/Conversation")]
public class ConversationOBJ : ScriptableObject
{

    // Start is called before the first frame update
    public string[] Sentences;
    // we will compare each sentecne spoken to the speaker array to see who is speaking
    public int[] Speaekr;
    public int speakerValue;
    public bool ShouldConvoEnd;
  //if not
    public ChoiceOption[] ChoiceOptions;
    public string[] ChoicesText;

}