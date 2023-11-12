using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class jsonReadWrite : MonoBehaviour
{
    public InputField InputUserName;
    public InputField InputPassword;

    public void SaveToJson()
    {
        FormLogin data = new FormLogin();

        data.userName = InputUserName.text;
        data.password = InputPassword.text;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.dataPath + "/FormLogin.json", json);
    }
}
