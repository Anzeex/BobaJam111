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
    GameObject player;
    public ConversationOBJ[] Sports;
    public ConversationOBJ[] Gossip;
    public ConversationOBJ[] Humor;
    public ConversationOBJ[] Crush;
    public ConversationOBJ[] FailCovnos;
    public ConversationOBJ convoToParse;
    public DialogueManager Dsystem;
    public AudioSource thisscource;
    public AudioClip audioClip;
    public Animator[] CrewAnimators;
    public AnimationClip[] respectiveclips;
    public TopDownController Playerplayer; 
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
        Playerplayer.canwalk = false;
        SceneManager.sceneLoaded += OnSceneLoaded;
        thisscource = GetComponent<AudioSource>();
        StartCoroutine(introAnims());
       
    }
    public IEnumerator introAnims()
    {
       
        for (int i = 0; i < CrewAnimators.Length; i++)
        {
            CrewAnimators[i].SetTrigger("intro");
            print("animdoneforintro");
        }

        yield return new WaitForSeconds(5);
        Playerplayer.canwalk = true;    
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
                        if (convoToParse.speakerValue < 3)
                        {
                            int currentSubjectLevel = 0;
                            if (convoToParse.speakerValue == 0)
                            {
                                //sports
                                currentSubjectLevel = sportsLevel;
                            }
                            if (convoToParse.speakerValue == 1)
                            {
                                //sports
                                currentSubjectLevel = gossipLevel;
                            }
                            if (convoToParse.speakerValue == 2)
                            {
                                //sports
                                currentSubjectLevel = humorLevel;
                            }
                            if (crushLevel < currentSubjectLevel)
                            {
                                StartCoroutine(Dsystem.StartDialogue(FailCovnos[convoToParse.speakerValue]));
                            }
                            else
                            {
                                StartCoroutine(Dsystem.StartDialogue(convoToParse));
                            }
                            
                        }
                    else
                        {
                            StartCoroutine(Dsystem.StartDialogue(convoToParse));
                        }
                       
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
        Debug.Log("ExitConvo called");
        SceneManager.LoadScene("AnzeeMovementScene", LoadSceneMode.Single);
        Debug.Log("ExitConvo completed");
    }
}