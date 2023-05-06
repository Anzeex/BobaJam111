using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
[CreateAssetMenu(fileName = "choiceOption", menuName = "ScriptableObjects/choiceOption")]

public class ChoiceOption : ScriptableObject
{
    public bool ShouldkeepTalking;
    public ConversationOBJ NextConvo;
    public NPC.AbilityType Abilitytype;
    

}

