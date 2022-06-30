using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    //Stores the animator
    public Animator animator;
    //Stores the animators text
    public Text AnimatorText;

    private void Start()
    {
        //Gets the animation clip that will play
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Gameobject will destroy itself after the animation is done
        Destroy(gameObject, clipInfo[0].clip.length);
    }

    public void SetText(string text)
    {
        //Changes the text of floating text
       AnimatorText.text = text;
    }
}
