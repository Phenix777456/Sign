using UnityEngine;

public class AlarmTriggerer : MonoBehaviour
{
    private bool _isKickIn = false;

    private void OnTriggerEnter2D(Collider2D hero)
    {
        if (hero.GetComponent<Hero>())
        {
            _isKickIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D hero)
    {
        if (hero.GetComponent<Hero>())
        {
            _isKickIn = false;
        }
    }

    public bool ReturnIsKickIn()
    {
        return _isKickIn; 
    }
}
