using UnityEngine;
using System.Collections.Generic;

public class Player : Character
{
    private void Awake()
    {
        Rig = GetComponent<Rigidbody2D>();

        InitialSpeed = Speed;
        CanMove = true;
        CanClick = true;
    }

    private void Update()
    {

    }
}