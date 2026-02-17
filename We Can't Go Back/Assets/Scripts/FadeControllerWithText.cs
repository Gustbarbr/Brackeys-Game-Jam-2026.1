using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeControllerWithText : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeImage;
    public float fadeDuration = 1f;

    [Header("Transition Text")]
    public TextMeshProUGUI transitionText;
    public float textDuration = 2f;
    [TextArea] public string message;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeWithMessageAndLoad(string sceneName)
    {
        StartCoroutine(FadeSequence(sceneName));
    }

    IEnumerator FadeSequence(string sceneName)
    {
        yield return StartCoroutine(FadeOut());

        transitionText.text = message;
        transitionText.gameObject.SetActive(true);

        yield return new WaitForSeconds(textDuration);

        transitionText.gameObject.SetActive(false);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            SetAlpha(1f - (t / fadeDuration));
            yield return null;
        }
        SetAlpha(0f);
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            SetAlpha(t / fadeDuration);
            yield return null;
        }
        SetAlpha(1f);
    }

    void SetAlpha(float a)
    {
        fadeImage.color = new Color(0, 0, 0, a);
    }
}
