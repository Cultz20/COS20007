using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class IdentifiableObject
{
    private List<string> _identifiers;

    public IdentifiableObject(string[] idents) 
    {
        _identifiers = new List<string>(idents);
    }

    public bool AreYou(string id)
    { 
        return _identifiers.Contains(id); 
    }

    public string FirstID
    { get { return _identifiers[0]; } }
    public void AddIdentifier(string id)
    {
        _identifiers.Add(id.ToLower());
    }

    public void PrivilegeEscalation(string pin)
    {
        string studentId = "104773652";
        string tutorialId = "COS20007"; 

        if (studentId.Length >= 4 && pin == studentId.Substring(studentId.Length - 4))
        {
            if (_identifiers.Count > 0)
            {
                _identifiers[0] = tutorialId;
            }
        }
    }
}