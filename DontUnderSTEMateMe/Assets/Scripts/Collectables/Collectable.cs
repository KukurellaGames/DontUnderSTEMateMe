using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[Serializable]
public class Collectable
{
    public string title;
    public string description;
    public string image;
    public bool pickup;
}

[Serializable]
public class CollectableListInfo
{
    public List<Collectable> collectables;
}
