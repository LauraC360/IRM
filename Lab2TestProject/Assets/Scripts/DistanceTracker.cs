using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TMP_Text distanceText;
    public TMP_Text decisionText;

    public GameObject startPoint;
    public GameObject endPoint;

    private bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        decisionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = new Vector3(startPoint.transform.position.x, 0, startPoint.transform.position.z);
        Vector3 endPosition = new Vector3(endPoint.transform.position.x, 0, endPoint.transform.position.z);

        // Calculam distanța orizontală
        float distance = Vector3.Distance(startPosition, endPosition);

        // Aproximam distanta
        float roundedDistance = Mathf.Round(distance);

        // Afisam scorul aproximat
        distanceText.text = "Scor: " + roundedDistance.ToString();

        // Verificam daca scorul este mai mare de 50
        if (roundedDistance > 50 && !hasWon)
        {
            // Player-ul a castigat
            hasWon = true;

            decisionText.text = "You win!";
            decisionText.gameObject.SetActive(true);

            
            StartCoroutine(PlayWinAnimation());
        }
    }

    IEnumerator PlayWinAnimation()
    {
        float duration = 1.0f;
        float elapsedTime = 0f;
        Vector3 originalScale = decisionText.transform.localScale;
        Vector3 targetScale = originalScale * 1.5f; 

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            decisionText.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            yield return null; 
        }

        decisionText.transform.localScale = originalScale;
    }
}
