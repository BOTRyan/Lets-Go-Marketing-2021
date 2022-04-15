using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimation : MonoBehaviour
{

    public AnimatorOverrideController[] animationControllers;
    //public Animator[] animations;
    //public RuntimeAnimatorController[] animations;
    public Animator myAnimator;

    [Range(0, 2)]
    public int playerAction = 0;
    private int p_playerAction = 0;


    [Range(0, 5)]
    public int playerColor = 0;
    private int p_playerColor = 0;
    public enum Color { red = 0, yellow = 1, green = 2, blue = 3, purple = 4, pink = 5}; // color number

    public enum State {sitting = 0, walkingUp = 1, walkingDown = 2}; // state number

    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() // maybe this is why things are doing stuff
    {

    }

    public void ChangeColor(int col)
    {
        myAnimator.runtimeAnimatorController = animationControllers[col]; // color number
    }

    public void ChangeState(int action) // for some reason this isn't working, yeah I'm totally lost idk what happened
    {
        Debug.Log("change state?" + action);
        playerAction = action;

        myAnimator.SetInteger("Action", playerAction); // State number
    }
}
