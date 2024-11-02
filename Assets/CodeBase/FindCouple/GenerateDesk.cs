using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateDesk : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int cardCount = 16;
    private int[][] cardsUnitPos;

    [SerializeField] private float xOffset = 1.25f;
    [SerializeField] private float yOffset = 1.25f;
    [SerializeField] private int colCardsNum = 4;
    [SerializeField] private int rowCardsNum = 4;
    
    private void Start()
    {
        cardsUnitPos = new int[colCardsNum][];
        for (int i = 0; i < colCardsNum; i++)
        {
            cardsUnitPos[i] = new int[rowCardsNum];
        }
        List<Card> cards = GenerateCards();
        Shuffle(cards);
        SetCards(cards);
    }


    private void Shuffle(List<Card> cards)
    {
        for (int i = 0; i < colCardsNum; i++)
        {
            for (int j = 0; j < rowCardsNum; j++)
            {
                cardsUnitPos[i][j] = cards.ElementAt(i * rowCardsNum + j).GetComponent<Card>().Type;
            }
        }
        for (int i = 0; i < colCardsNum; i++)
        {
            for (int j = 0; j < rowCardsNum; j++)
            {
                int xRand = Random.Range(0, rowCardsNum);
                int yRand = Random.Range(0, colCardsNum);


                int tmp = cardsUnitPos[i][j];
                cardsUnitPos[i][j] = cardsUnitPos[yRand][xRand];
                cardsUnitPos[yRand][xRand] = tmp;
            }
        }





    }

    private void SetCards(List<Card> cards)
    {
        for (int i = 0; i < colCardsNum; i++)
        {
            for (int j = 0; j < rowCardsNum; j++)
            {
                for (int k = 0; k < cards.Count; k++)
                {
                    if (!cards[k].isSet && cardsUnitPos[i][j] == cards[k].Type)
                    {
                        cards[k].isSet = true;
                        Transform cardTransform = cards[k].GetComponent<Transform>();
                        cardTransform.position = new Vector2(j * yOffset - yOffset * (colCardsNum / 2) + yOffset / 2, i * xOffset - xOffset * (rowCardsNum / 2) + xOffset / 2);
                        //TODO переработать
                        cardTransform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                        break;
                    }
                }
            }
        }
    }
    


    private List<Card> GenerateCards()
    {
        List<Card> cardsTransform = new List<Card>();
        int cardCountLeft = cardCount;
        for (int i = 0; i < images.Length - 1; i++)
        {
            int currentCards = Random.Range(0, (int)(cardCountLeft / 2)) * 2;

            for (int j = 0; j < currentCards; j++)
            {
                Card c = Instantiate(cardPrefab);
                cardsTransform.Add(c);
                c.SetFrontSprite(images[i]);
                c.SetType(i);
                c.CloseCard();
            }
            cardCountLeft -= currentCards;
        }



        if (cardCountLeft > 0)
        {
            for (int i = 0; i < cardCountLeft; i++)
            {
                Card c = Instantiate(cardPrefab);
                cardsTransform.Add(c);
                c.SetFrontSprite(images[images.Length - 1]);
                c.SetType(images.Length - 1);
                c.CloseCard();
            }
        }


        


        return cardsTransform;
    }
    
}
