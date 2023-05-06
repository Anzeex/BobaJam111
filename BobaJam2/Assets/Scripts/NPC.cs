using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    public AbilityType abilityToTrain;

    public enum AbilityType
    {
        Sports,
        Gossip,
        Humor
    }

    public void TrainAbility(Player player)
    {
        if (player != null)
        {
            player.TrainAbility(abilityToTrain);
            Debug.Log($"trained {player.gameObject.name} in {abilityToTrain}!");
        }
        else
        {
            Debug.LogError("player reference not set!");
        }
    }
}
