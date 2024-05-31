using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
[CreateAssetMenu(fileName = "New Passwords", menuName = "ScriptableObjects/Passwords", order = 0)]
public class Passwords : ScriptableObject
{
    public List<string> passwords;  // Corrected 'pubic' to 'public'
    public string filePath;

    [ContextMenu("Add Password")]  // Corrected 'ConextMenu' to 'ContextMenu'
    public void AddPassword()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var item in lines)
            {
                if (!passwords.Contains(item))
                {
                    passwords.Add(item);
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}