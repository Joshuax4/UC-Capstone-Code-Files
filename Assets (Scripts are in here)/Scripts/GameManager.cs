using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;
    public Timer timer;
    private bool _init = false;
    private int _matches = 13;


    // Update is called once per frame
    void Update()
    {
        if (!_init) //This loads all images before they are needed on the screen.
            //Doesn't hit the update until everything is loaded
            initialiseCards();
        if (Input.GetMouseButtonUp(0)) //Will need to change this for VR - programmed to work on mouse click
            checkCards();
    }

    void initialiseCards()
    {
        for (int id = 0; id < 2; id++) //Cycles twice to add all card values twice. PAIRS
        {
            for (int i = 1; i < 14; i++) //Assign card values to all cards
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialised);
                    //As it is a random number, test checks if a card has already been initialised - if it has the while loop continues, if not, continue to next line
                }
                cards[choice].GetComponent<Card>().cardValue = i; //Initialises card
                cards[choice].GetComponent<Card>().initialised = true; //Sets initialised to true, ensuring while loop continues if number is hit
            }
        }

        foreach (GameObject c in cards)
            c.GetComponent<Card>().setupGraphics(); //Cards now have values and can set up graphics
        if (!_init)
            _init = true; //Catches if any cards haven't been initialised.
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }
    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1) //If card is flipped over
                c.Add(i); //adds i (1) to list of ints
        }
        if (c.Count == 2)

            cardComparison(c); //Sorting cards, if card is face up add to list
                               //if two face up cards - compare them.

    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true; //tell cards to stop doing anything
        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue) //If cards match
        {
            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches; //This is where to alter displayed text
            if (_matches == 0)
            {
                timer.running = false; // failing here. 
                wait5();
                SceneManager.LoadScene("Menu");
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x; //Puts it in a checking state
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
    IEnumerator wait5()
    {
        yield return new WaitForSeconds(5);
    }
}