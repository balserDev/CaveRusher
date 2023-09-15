using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linking : MonoBehaviour
{
    public void Hyperlink (string URL)
    {
        Application.OpenURL(URL);
    }
}
