using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField = default;
    [SerializeField] private TMP_InputField emailInputField = default;
    [SerializeField] private TMP_InputField passwordeInputField = default;

    public static string SessionTicket;
    public static string EntityId;

    public void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = usernameInputField.text,
            Email = emailInputField.text,
            Password = passwordeInputField.text
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            SceneManager.LoadScene("Lobby");
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }

    public void SignIn()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = usernameInputField.text,
            Password = passwordeInputField.text
        }, result =>
        {
            SessionTicket = result.SessionTicket;
            EntityId = result.EntityToken.Entity.Id;
            SceneManager.LoadScene("Lobby");
        }, error =>
        {
            Debug.LogError(error.GenerateErrorReport());
        });
    }
}
