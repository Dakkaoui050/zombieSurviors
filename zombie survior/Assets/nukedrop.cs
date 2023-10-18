using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class nukedrop : MonoBehaviour
{
    public CanvasGroup flash;
    public float fadeDuration = 2.0f; // Duration of the fade in seconds
    public List<GameObject> Zombies = new List<GameObject>();
    public AudioSource source;
    public player p;



    private IEnumerator FadePanel()
    {
        float elapsedTime = 0;
        float startAlpha = 0.75f; // Starting alpha value
        float targetAlpha = 0.0f; // Ending alpha value

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value based on the elapsed time
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Set the alpha value of the CanvasGroup
            flash.alpha = newAlpha;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        flash.alpha = targetAlpha;
    }
    public void Nuke_Drop(player invoke)
    {
        p = invoke;
        source.Play();
        foreach (GameObject enemy in Zombies)
        {
            enemy.GetComponent<Enemy>().Play();

        }
            Invoke(nameof(NukeDrop), 2);
    }
    public void NukeDrop()
    {
        StartCoroutine(FadePanel());
        
            foreach (GameObject zombie in Zombies)
            {
                Destroy(zombie);
            }
            Zombies.Clear();
        
    }
    private void FixedUpdate()
    {
        foreach (var t in Zombies)
        {
            if (t == null)

            {
                Zombies.Remove(t);
            }
        }
    }

}
