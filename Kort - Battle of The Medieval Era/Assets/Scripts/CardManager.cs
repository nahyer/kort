﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] DeckPanel deckPanel;
    [SerializeField] CardsCollection cardsCollection;

    public void MoveCardToDeck(Card card) //equip
    {

        if (!deckPanel.IsFull()) //deck ga penuh
        {
            if (cardsCollection.RemoveCard(card))
            {
                if (deckPanel.AddCard(card))
                {
                    Debug.Log("Card added to the deck.");
                    //int idx = cardsCollection.FindIndexCard(card);
                    //cardsCollection.SetCard(idx, null); //hapus untuk tampilan
                } else {
                    Debug.Log("failed to add card");
                    cardsCollection.AddCard(card); //put back
                }
            }
            else
            {
                Debug.Log("failed to remove card from collection");
            }
        } else {
            Debug.Log("Deck is full.");
        }
    }
    public void MoveCardToCollection(Card card) //unequip
    {
        if(!cardsCollection.IsFull()) // deck ga penuh
        {
            if (deckPanel.RemoveCard(card))
            {
                cardsCollection.AddCard(card);
                Debug.Log("Card added to the collection.");
            } else {
                Debug.Log("Failed to remove card.");
            }
        } else {
            Debug.Log("Card Collection is full.");
        }
    }

    private void Awake()
    {
        cardsCollection.OnCardRightClickedEvent += MoveCardToDeck;
        deckPanel.OnCardRightClickedEvent += MoveCardToCollection;
    }


}
