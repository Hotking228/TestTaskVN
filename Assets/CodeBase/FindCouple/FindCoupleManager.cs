using Naninovel;
using Naninovel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindCoupleManager : MonoBehaviour
{
    private Card firstOpened;
    private int openedCards;
    private bool interactible = true;
    [SerializeField] private GenerateDesk generateDesk;
    [SerializeField] private ImpactEffect impactEffectFlipCard;
    [SerializeField] private ImpactEffect impactEffectWin;
    [SerializeField] private ImpactEffect impactEffectMistake;
    Script naniScript;

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
                        CheckCard(card);
                    }
                }
            }
        }
    }

    private void CheckCard(Card card)
    {
        Instantiate(impactEffectFlipCard, Vector3.zero, Quaternion.identity);
        if (firstOpened == null)
            firstOpened = card;
        card.OpenCard();
        
        if(firstOpened != card)
        {
            //если карты не совпадают
            if (firstOpened.Type != card.Type)
            {
                Instantiate(impactEffectMistake, Vector3.zero, Quaternion.identity);
                StartCoroutine(CloseCardsAfterTime(2f, card));
            }
            //если совпадают
            if (firstOpened.Type == card.Type)
            {
                Instantiate(impactEffectWin, Vector3.zero, Quaternion.identity);
                firstOpened = null;
                openedCards += 2;
                if (openedCards == generateDesk.CardCount)
                {
                    PlayerBag.Instance.ChangeScore(5);
                    SceneManager.LoadScene(2);
                    var scriptPlayer = Engine.GetService<ScriptPlayer>();

                    scriptPlayer.PlayFromLabel("StartNewLevel");
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
