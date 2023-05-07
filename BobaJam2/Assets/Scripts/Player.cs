using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GamemanagerScript Gamemanager;
    public TopDownController mmTroller;
    public Animator Wincon;
    public AudioSource so;
    public AudioClip clip;
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
        Wincon.SetTrigger("win");
        mmTroller.canwalk = false;
        so.clip= clip;
        so.Play();
    }
}
