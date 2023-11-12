using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class LoginManage : MonoBehaviour
{
    public TextAsset userJson;

    public InputField userName;
    public InputField password;
    public Button loginButton;
    public Button toSignUp;


   

    private List<FormSignUp> users = new List<FormSignUp>();

    public void LoginClick()
    {
        string username = userName.text;
        string pass = password.text;

        bool isLoggedIn = Login(username, pass);

        if (isLoggedIn == true)
        {
            Debug.Log("thanh cong");

            SceneManager.LoadScene("Home");
        }
        else
        {
            Debug.Log("That bai");
        }


    }

    public bool Login(string UserName, string Password)
    {
        FormSignUp user = users.Find(u => u.UserName == UserName && u.Password == Password);
        return user != null;

    }

    public void ToSignUpClicked()
    {
        SceneManager.LoadScene("SignUp");
    }
}
