using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPositions : MonoBehaviour
{
    #region Singleton

    public static GrabPositions instance;
    public List<Transform> boardPositions = new List<Transform>();

    private void Awake()
    {
        instance = this;
    }

    #endregion
}
