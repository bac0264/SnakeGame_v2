﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle
    : _Object{

    private void StaAwakert()
    {
        tag = type.ToString();
        gameObject.tag = tag;
    }
    public override void spin()
    {
    }
    public override void move()
    {
    }
}
