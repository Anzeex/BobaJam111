using UnityEngine;

public class Player : MonoBehaviour
{
    public int sportsLevel;
    public int gossipLevel;
    public int humorLevel;

    public void TrainAbility(NPC.AbilityType abilityType)
    {
        switch (abilityType)
        {
            case NPC.AbilityType.Sports:
                sportsLevel++;
                break;
            case NPC.AbilityType.Gossip:
                gossipLevel++;
                break;
            case NPC.AbilityType.Humor:
                humorLevel++;
                break;
        }
    }
}
