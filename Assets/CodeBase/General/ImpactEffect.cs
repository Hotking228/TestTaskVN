using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;

    private void Start()
    {
        StartCoroutine(EndEffect());
    }



    private IEnumerator EndEffect()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
