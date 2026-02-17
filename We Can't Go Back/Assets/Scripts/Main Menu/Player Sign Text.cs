using TMPro;
using UnityEngine;

public class PlayerSignText : MonoBehaviour
{
    public TMP_InputField inputField;
    public int maxLength = 12;

    [SerializeField] private TextMeshProUGUI placeholderText;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        placeholderText = inputField.placeholder as TextMeshProUGUI;
    }

    private void Start()
    {
        inputField.characterLimit = maxLength;
        UpdatePlaceholder(inputField.text);
    }

    public bool HasValidName => !string.IsNullOrWhiteSpace(inputField.text);
    public string PlayerName => inputField.text;

    public void OnValueChanged(string value)
    {
        UpdatePlaceholder(value);
    }

    private void UpdatePlaceholder(string value)
    {
        if (placeholderText == null) return;

        placeholderText.enabled = string.IsNullOrEmpty(value);
    }
}
