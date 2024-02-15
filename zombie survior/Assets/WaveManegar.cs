using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class WaveManegar : MonoBehaviour
{
    public List<GameObject> Zombies = new List<GameObject>();
    public CanvasGroup flash;
    public float fadeDuration = 2.0f; // Duration of the fade in seconds
    public AudioSource source;
    [SerializeField] private nukedrop nd;
    public spawnscript ss;

    private void Awake()
    {
        ss = GameObject.FindWithTag("Spawn").GetComponent<spawnscript>();
        nd = GameObject.FindWithTag("Gamemaster").GetComponent<nukedrop>();
        nd.Waves.Add(gameObject);
        flash = GameObject.Find("Player").GetComponentInChildren<CanvasGroup>();
    }
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
        if(!source.isPlaying)
        {
            Destroy(gameObject);
        }
    }
    public void Nuke_Drop()
    {
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
        ss.enemies.DefaultIfEmpty();
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
