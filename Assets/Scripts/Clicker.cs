using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private int _buttomNumber = 0;

    public event Action ClickedButtom;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttomNumber))
        {
            ClickedButtom?.Invoke();
        }
    }
}
