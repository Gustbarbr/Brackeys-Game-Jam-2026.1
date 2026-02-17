using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    [Header("Config")]
    public float typingSpeed = 0.04f;

    [TextArea(3, 5)]
    public string[] dialogueLines;

    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping;
    private string playerName;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Player");
        StartDialogue();
    }

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            OnClick();

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            OnClick();
    }

    void StartDialogue()
    {
        currentLineIndex = 0;
        ShowLine();
    }

    void OnClick()
    {
        if (isTyping)
            FinishTyping();
        else
            NextLine();
    }

    void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = $"{playerName}: ";

        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void FinishTyping()
    {
        StopCoroutine(typingCoroutine);
        dialogueText.text = $"{playerName}: {dialogueLines[currentLineIndex]}";
        isTyping = false;
    }

    void NextLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        ShowLine();
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
    }
}
