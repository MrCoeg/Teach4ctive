using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCredentials", menuName = "ScriptableObjects/NewCredentials", order = 1)]
public class Credentials : ScriptableObject
{
    public List<int> id = new List<int>();
    public List<string> fullname = new List<string>();
    public List<string> gender = new List<string>();
    public List<string> birthdate = new List<string>(); // You might want to use DateTime, but it's not recommended for ScriptableObjects
    public List<string> handphoneNumber = new List<string>();
    public List<string> province = new List<string>();
    public List<string> city = new List<string>();
    public List<string> email = new List<string>();
    public List<string> password = new List<string>(); // Be cautious with storing passwords like this

    public bool CheckCredentials(string emailInput, string passwordInput)
    {
        for (int i = 0; i < email.Count; i++)
        {
            if (email[i] == emailInput && password[i] == passwordInput)
            {
                return true; // Email and password match found
            }
        }
        return false; // No match found
    }
}
