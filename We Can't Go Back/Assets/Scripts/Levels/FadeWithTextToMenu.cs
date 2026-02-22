using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeWithTextToMenu : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;              
    public float fadeDuration = 2f;      

    [Header("Text")]
    public TextMeshProUGUI messageText;   
    [TextArea] public string message;
    public float textDuration = 3f;

    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        SetAlpha(0f);
        messageText.gameObject.SetActive(false);
    }

    public void StartFade()
    {
        if (player == null)
            player = GameObject.Find("Player");

        if (enemy == null)
            enemy = GameObject.Find("Special Enemy Type 2(Clone)");

        if (player != null)
        {
            MonoBehaviour[] scripts = player.GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }

            Renderer[] renderers = player.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }

            Collider[] colliders = player.GetComponentsInChildren<Collider>();
            foreach (Collider c in colliders)
            {
                c.enabled = false;
            }
        }

        if (enemy != null) enemy.SetActive(false);

        StartCoroutine(FadeSequence());
    }

    private IEnumerator FadeSequence()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            SetAlpha(t / fadeDuration);
            yield return null;
        }
        SetAlpha(1f);

        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(textDuration);

        messageText.gameObject.SetActive(false);

        SceneManager.LoadScene("Main Menu");
    }

    private void SetAlpha(float alpha)
    {
        fadeImage.color = new Color(0, 0, 0, alpha);
    }
}