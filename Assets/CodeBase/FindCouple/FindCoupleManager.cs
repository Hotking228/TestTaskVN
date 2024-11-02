using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoupleManager : MonoBehaviour
{
    private Card firstOpened;
    private int openedCards;
    private bool interactible = true;
    [SerializeField] private GenerateDesk generateDesk;
    private void Update()
    {
        if (!interactible) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction, 100);
            if (hit.collider != null)
            {
                Card card = hit.collider.GetComponent<Card>();
                if (card != null)
                {
                    if (card.IsClosed)
                    {
                        if (firstOpened == null)
                            firstOpened = card;
                        card.OpenCard();
                        if (firstOpened != card && firstOpened.Type != card.Type)
                        {
                            StartCoroutine(CloseCardsAfterTime(2f, card));
                        }
                        else if(firstOpened != card)
                        {
                            firstOpened = null;
                            openedCards += 2;
                            if (openedCards == generateDesk.CardCount)
                            {
                                PlayerBag.Instance.ChangeScore(5);
                            }
                        }
                    }
                }
            }
        }
    }


    private IEnumerator CloseCardsAfterTime(float time, Card secondOpened)
    {
        interactible = false;
        yield return new WaitForSeconds(time);
        firstOpened.CloseCard();
        secondOpened.CloseCard();
        firstOpened = null;
        interactible = true;
    }



}
