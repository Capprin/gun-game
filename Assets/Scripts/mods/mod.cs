using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Mod : MonoBehaviour {
    public abstract void Activate();
    public abstract string GetName();
}
