using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCoupleManager : MonoBehaviour
{
    private Card firstOpened;
    

    private void Update()
    {
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
                        }
                    }
                }
            }
        }
    }


    private IEnumerator CloseCardsAfterTime(float time, Card secondOpened)
    {
        yield return new WaitForSeconds(time);
        firstOpened.CloseCard();
        secondOpened.CloseCard();
        firstOpened = null;
    }



}
