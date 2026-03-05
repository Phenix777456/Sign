using System;
using UnityEngine;

public class AlarmTriggerer : MonoBehaviour
{
    public event Action<bool> IsEnteringTrigger;

    private bool _isKickIn = false;

    private void OnTriggerEnter2D(Collider2D hero)
    {
        if (hero.GetComponent<Hero>())
        {
            _isKickIn = true;
            IsEnteringTrigger?.Invoke(_isKickIn);
        }
    }

    private void OnTriggerExit2D(Collider2D hero)
    {
        if (hero.GetComponent<Hero>())
        {
            _isKickIn = false;
            IsEnteringTrigger?.Invoke(_isKickIn);
        }
    }
}
