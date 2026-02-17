using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public PlayerSignText playerSign;
    public Button playButton;
    public FadeControllerWithText fade;

    private void Start()
    {
        playButton.interactable = false;
    }

    public void OnNameChanged()
    {
        playButton.interactable = playerSign.HasValidName;
    }

    public void PlayButton()
    {
        if (!playerSign.HasValidName)
            return;

        PlayerPrefs.SetString("PlayerName", playerSign.PlayerName);
        PlayerPrefs.Save();

        fade.message = "War takes you to strange places...both in the mind and in reality.";
        fade.FadeWithMessageAndLoad("Game");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
