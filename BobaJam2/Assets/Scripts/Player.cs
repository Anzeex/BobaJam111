using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamemanagerScript Gamemanager;

    private void Start()
    {
        Gamemanager = GameObject.FindObjectOfType<GamemanagerScript>();
        if ( Gamemanager.crushLevel == 3)
        {
            Win();
        }
    }
    public void TrainAbility(NPC.AbilityType abilityType)
    {

        switch (abilityType)
        {
            case NPC.AbilityType.Sports:
                //Gamemanager.sportsLevel++;
                break;
            case NPC.AbilityType.Gossip:
                //Gamemanager.gossipLevel++;
                break;
            case NPC.AbilityType.Humor:
                //Gamemanager.humorLevel++;
                break;
        }
    }
    public void Win() 
    {
       //win
    }
}
