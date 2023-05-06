using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemanagerScript : MonoBehaviour
{


    public NPC.AbilityType abilityType = NPC.AbilityType.Empty;
    public int sportsLevel;
    public int gossipLevel;
    public int humorLevel;
    public int crushLevel;
    public int scenenum;
    public ConversationOBJ[] Sports;
    public ConversationOBJ[] Gossip;
    public ConversationOBJ[] Humor;
    public ConversationOBJ[] Crush;
    public ConversationOBJ convoToParse;
    public DialogueManager Dsystem;
    // Start is called before the first frame update

    private static GamemanagerScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            if (scenenum == 2)
            {
                print("done!");
                Dsystem = GameObject.FindObjectOfType<DialogueManager>();
                if (abilityType != NPC.AbilityType.Empty)
                {
                    switch (abilityType)
                    {
                        case NPC.AbilityType.Sports:
                            convoToParse = Sports[sportsLevel];
                            break;
                        case NPC.AbilityType.Gossip:
                            convoToParse = Gossip[gossipLevel];
                            break;
                        case NPC.AbilityType.Humor:
                            convoToParse = Humor[humorLevel];
                            break;
                        case NPC.AbilityType.Crush:
                            convoToParse = Crush[crushLevel];
                            break;

                    }
                    if(Dsystem != null)
                        StartCoroutine(Dsystem.StartDialogue(convoToParse));
                }
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    public void StartConvo(NPC.AbilityType abilitytype)
    {
        abilityType= abilitytype;
        SceneManager.LoadScene("MicnastieTestSCene", LoadSceneMode.Single);
        scenenum = 2;
    }
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
            case NPC.AbilityType.Crush:
                crushLevel++;
                break;
        }
    }
    public void ExitConvo(){
        SceneManager.LoadScene("AnzeeMovementScene", LoadSceneMode.Single);
    }
}
