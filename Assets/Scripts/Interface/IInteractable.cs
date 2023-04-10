using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string Description { get; set; }

    public void Interact(GameObject obj);
}
