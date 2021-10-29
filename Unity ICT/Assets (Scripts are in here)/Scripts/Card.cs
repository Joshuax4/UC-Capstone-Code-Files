using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool DO_NOT = false; //When none of the cards should be flipped. Halts card flip process

    [SerializeField] 
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialised = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager"); 

    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }

    /*
                                                                                    BELOW IS THE CODE FOR FLIP CARD EFFECT. IT IS CURRENTLY BROKEN. 
                                                           IT IS INTENDED TO REPLACE "flipCard()" function, however I was unable to correctly get both cards to remain flipped in time. 


    */

    //public void Update() 
    //{
    //    if (_state == 1 && !DO_NOT)
    //    {
    //        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, 180, 5f * Time.deltaTime), transform.eulerAngles.z);
    //        if (transform.eulerAngles.y > 90)
    //        {
    //            GetComponent<Image>().sprite = _cardFace;
    //        }
    //    }

    //    else if (_state == 0 && !DO_NOT)
    //    {
    //        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, 0, 5f * Time.deltaTime), transform.eulerAngles.z);
    //        if (transform.eulerAngles.y < 90)
    //        {
    //            GetComponent<Image>().sprite = _cardBack;
    //        }

    //    }
    //}

    public void flipCard()
    {
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;

        if (_state == 0 && !DO_NOT) //If card is showing it's face, flip to it's back. 
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !DO_NOT)
            GetComponent<Image>().sprite = _cardFace; // If card shows back, show it's face

    }

    //}

    //Change the y value here. Should only have to add the y axis stuff here.
    /*
        PSUEDO: 
            rotate y axis from 0 - 180
            if y > 90:
                show front sprite
            else if y < 90:
                show front sprite
            Need to know how to influence speed of card flip in float I've referred to as rotationSpeed
            Apparently need Time.deltaTime (????)
     */

    //if (_state == 0 && !DO_NOT)
    //{ //If card is showing it's face, flip to it's back. 
    //    runCardUp();
    //    //transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, 180, 0.5f * Time.deltaTime), transform.eulerAngles.z);
    //    //if (transform.eulerAngles.y > 90)
    //    //{
    //    //    GetComponent<Image>().sprite = _cardBack;
    //    //}
    //}
    //else if (_state == 1 && !DO_NOT)
    //{ //If card is showing it's back, flip to it's face. 
    //    runCardDown();
    //}


    public int cardValue
    {
        get { return _cardValue; } //Returns the card value
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; } 
    }

    public bool initialised
    {
        get { return _initialised; }
        set { _initialised = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause()); //This is the buffer to check if cards are a match. How long you should wait to flip the card back over - HANDY FOR EXPERIMENT. MEASURE AVG TIME
    }

    IEnumerator pause() 
    {
        yield return new WaitForSeconds(1); //This can be configured to make pause last longer or shorter depending on what is required. 
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        DO_NOT = false;
    }
}