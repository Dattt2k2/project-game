using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Security;
using System;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

[System.Serializable]

public class SignUpJson : MonoBehaviour
{

    public InputField UserName;
    public InputField Password;
    public InputField Email;
    public InputField Repass;

    public Button SignUpBtn;
    public Button ToLoginBtn;
    

    private List<FormSignUp> users = new List<FormSignUp>();
    private string dataPath;
    

    private void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "FormSignUp.json");
        LoadUserData();
    }

    public void SignUp()
    {
        string pass = Password.text;
        string repass = Repass.text;
        if(pass == repass)
        {
            Debug.Log("Mat Khau Giong Nhau");
            FormSignUp newUser = new FormSignUp
            {
                UserName = UserName.text,
                Password = Password.text,
                Email = Email.text
            };
            users.Add(newUser);
            Debug.Log(newUser.Email);
            Debug.Log(newUser.UserName);
            Debug.Log(newUser.Password);
            SaveUserData();
            SceneManager.LoadScene("LogIn");
        }

        
    }

    

    

    private void SaveUserData()
    {
        string json = JsonUtility.ToJson(users);
        File.WriteAllText(dataPath, json);
    }

    private void LoadUserData()
    {
        if(File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            users = JsonUtility.FromJson<List<FormSignUp>>(json);
        }
    }

    public void ToLoginClicked()
    {
        SceneManager.LoadScene("LogIn");
    }

    //public InputField InputUserName;
    //public InputField InputPassword;
    //public InputField InputRePass;
    //public InputField InputEmail;

    //public string filePath = "FormSignUp.json";



    //void Start()
    //{
    //    CreateInitialJSON();
    //    Debug.Log("File chay den phan nay");
    //}

    //private void CreateInitialJSON()
    //{
    //    if (!File.Exists(filePath))
    //    {
    //        FormSignUp initalData = new()
    //        {
    //            UserName = "default_userName",
    //            Password = "Password",
    //            Email = "default_email"
    //        };

    //        string jsonData = JsonUtility.ToJson(initalData);
    //        File.WriteAllText(filePath, jsonData);

    //        Debug.Log("File chay den day");
    //    }
    //}

    //public void UpdateJSONData()
    //{
    //    string pass = InputPassword.text;
    //    string repass = InputRePass.text;
    //    string json = File.ReadAllText(filePath);
    //    FormSignUp exsitingData = JsonUtility.FromJson<FormSignUp>(json);
    //    if(pass == repass)
    //    {
    //        if(exsitingData != null)
    //        {
    //            exsitingData.UserName = InputUserName.text;
    //            exsitingData.Email = InputEmail.text;
    //            exsitingData.Password = InputPassword.text;

    //            string updateJson = JsonUtility.ToJson(exsitingData);
    //            File.WriteAllText (filePath, updateJson);

    //            Debug.Log("Hai mat khau giong nhau");
    //            Debug.Log(updateJson);
    //        }
    //    }

    //}



    /* public void SaveToJson()
    {


        string pass = InputPassword.text;
        string repass = InputRePass.text;
        string email = InputEmail.text;
        

         if(pass == repass)
        {
            string path = Application.persistentDataPath + "/FormSignUp.json";
            string json = File.ReadAllText("/FormSignUp.json");
            if (!Directory.Exists(Application.persistentDataPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath);
            }
            Debug.Log("/FormSignUp.json" + path);

            
            FormSignUp data = JsonUtility.FromJson<FormSignUp>(json);
            data.Email = InputEmail.text;
            data.UserName = InputUserName.text;
            data.Password= InputPassword.text;

            Debug.Log("Hai Mat Khau Trung Nhau");
            

            string updateJson = JsonUtility.ToJson(data);

            File.WriteAllText(path, updateJson);
        }
        else
        {
            Debug.Log("Nhap lai mat khau khong dung");
        }

        
    }*/
}
