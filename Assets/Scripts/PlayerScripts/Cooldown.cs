using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    [HideInInspector] public bool OnCooldown;

    public IEnumerator ActivateCooldown(int CooldownTime)
    {
        OnCooldown = true;
        this.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(CooldownTime);
        OnCooldown = false;
        this.GetComponent<Button>().interactable = true;
    }
}
