using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // The UI text element to display the dialogue
    public Text dialogueText;

    // The speed at which each character is displayed (in seconds)
    public float typingSpeed = 0.05f;

    // The current dialogue being displayed
    private string currentDialogue;

    // Coroutine to display the dialogue one character at a time
    private Coroutine typingCoroutine;

    public Image[] speakers;
    private bool Newsentecne;
    // Start displaying the dialogue
    private int sentecneOn;
    public int currentSpeaker = 0;
    public GamemanagerScript Gamemanager;
    public ConversationOBJ Currentconvo;
    public ConversationOBJ crushLevelFail;
    public GameObject[] choicecards;
    public GameObject[] choicecardsText;
    public Sprite[] speakersImages;
    public bool[] LevelChecks;
    public AudioSource typeSound;
    public AudioClip[] soundarray;
    public bool isTyping;
    public IEnumerator StartDialogue(ConversationOBJ conversationtoospeak)
    {
        sentecneOn= 0;
        Currentconvo= conversationtoospeak;
        speakers[0].sprite = speakersImages[conversationtoospeak.speakerValue];
        // Stop any currently running typing coroutine
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        for (int i = 0; i < conversationtoospeak.Sentences.Length; i++)
        {
            // Save the current dialogue
            currentDialogue = conversationtoospeak.Sentences[i];
            print(i);
            speakerCALL(conversationtoospeak.Speaekr[i]);
            // Start the typing coroutine to display the dialogue
            typingCoroutine = StartCoroutine(TypeDialogue());
            yield return new WaitForSeconds(1);
            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
        }
        if(!conversationtoospeak.ShouldConvoEnd)
        {
            print((conversationtoospeak.ChoiceOptions.Length)+ "this is TerrainHeightmapSyncControl");
            DisplayChoices(conversationtoospeak.ChoiceOptions.Length);
        }



        
    }
    public void speakerCALL(int speaker)
    {
        speakers[0].color = new Color(1f, 1f, 1f);
        speakers[1].color = new Color(1f, 1f, 1f);
        speakers[speaker].color = new Color(85 / 255f, 85 / 255f, 85 / 255f);
    }

    // Coroutine to display the dialogue one character at a time
    public IEnumerator TypeDialogue()
    {
        // Clear the dialogue text
        dialogueText.text = "";

        // Loop through each character in the dialogue
        for (int i = 0; i < currentDialogue.Length; i++)
        {
            // Add the current character to the dialogue text
            dialogueText.text += currentDialogue[i];
            PlayTypingSound();

            // Wait for the specified typing speed
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping= false;   
        // Set the typing coroutine to null when finished
        typingCoroutine = null;
    }

    // Wait until left mouse button is clicked
    public void DisplayChoices(int NumBofChoices)
    {
        dialogueText.text = "";
        if (NumBofChoices == 2)
        {
            choicecardsText[0].GetComponent<Text>().text = Currentconvo.ChoicesText[0];
            choicecards[0].SetActive(true);
            choicecardsText[2].GetComponent<Text>().text = Currentconvo.ChoicesText[1];
            choicecards[2].SetActive(true);
        }
        else
        {
            //used to be for loop, chenged becuase no work, sorry, not sorry
            //check if speaker is crush
            if(Currentconvo.speakerValue== 3)
            {
                print(Gamemanager.sportsLevel);
                if (Gamemanager.sportsLevel == (Gamemanager.crushLevel + 1))
                {
                    choicecardsText[0].GetComponent<Text>().text = Currentconvo.ChoicesText[0];
                    choicecards[0].SetActive(true);
                    LevelChecks[0] = true;
                }
                else
                {
                    choicecardsText[0].GetComponent<Text>().text = "";
                    choicecards[0].SetActive(true);
                }
                if (Gamemanager.gossipLevel == (Gamemanager.crushLevel + 1))
                {
                    choicecardsText[1].GetComponent<Text>().text = Currentconvo.ChoicesText[1];
                    choicecards[1].SetActive(true);
                    LevelChecks[1] = true;
                }
                else
                {
                    choicecardsText[1].GetComponent<Text>().text = "";
                    choicecards[1].SetActive(true);
                }
                if (Gamemanager.humorLevel == (Gamemanager.crushLevel + 1))
                {
                    choicecardsText[2].GetComponent<Text>().text = Currentconvo.ChoicesText[2];
                    choicecards[2].SetActive(true);
                    LevelChecks[2] = true;
                }
                else
                {
                    choicecardsText[2].GetComponent<Text>().text = "";
                    choicecards[2].SetActive(true);
                }
            }
            else
            {
                choicecardsText[0].GetComponent<Text>().text = Currentconvo.ChoicesText[0];
                choicecards[0].SetActive(true);
                choicecardsText[1].GetComponent<Text>().text = Currentconvo.ChoicesText[1];
                choicecards[1].SetActive(true);
                choicecardsText[2].GetComponent<Text>().text = Currentconvo.ChoicesText[2];
                choicecards[2].SetActive(true);
            }
           
        }
        
    }
    public void diolougeChooice(int choice)
    {
        print(choice);
        for (int i = 0; i < 3; i++)
        {
            choicecards[i].SetActive(false);
        }
        
        //Currentconvo.ChoiceOptions[choice].effectt();
        print(Currentconvo.ChoiceOptions.Length == 2);
        if (Currentconvo.ChoiceOptions.Length == 2)
        {
            print("here");
            if (choice == 2)
            {

                print("im in choice arg");
                if (Currentconvo.ChoiceOptions[1].ShouldkeepTalking)

                {
                    StartCoroutine(StartDialogue(Currentconvo.ChoiceOptions[1].NextConvo));
                }

            }
            else
            {
                print("amlost");
                if (Currentconvo.ChoiceOptions[0].ShouldkeepTalking)

                {
                    print("now");
                    StartCoroutine(StartDialogue(Currentconvo.ChoiceOptions[0].NextConvo));

                }
            }

        }
        else // 3 options 
        {
            if(Currentconvo.speakerValue == 3 && LevelChecks[choice] == false)
            {
                print("Level check failed");
                StartCoroutine(StartDialogue(crushLevelFail));
            }
            else
            {
                if (Currentconvo.ChoiceOptions[choice].ShouldkeepTalking)

                {
                    print("now");
                    StartCoroutine(StartDialogue(Currentconvo.ChoiceOptions[choice].NextConvo));
                }
            }

           
        }
        for (int i = 0; i < 3; i++)
        {
            LevelChecks[i] = false;
        }
    }
        
    
    public void PlayTypingSound()
    {
        isTyping= true;
        while (isTyping)
        {
            if (!typeSound.isPlaying)
            {
                typeSound.clip = soundarray[Random.Range(0, soundarray.Length)];
                typeSound.Play();
            }
                
        }
    }
    
    private void Start()
    {
        Gamemanager = GameObject.FindObjectOfType<GamemanagerScript>();
    }
}