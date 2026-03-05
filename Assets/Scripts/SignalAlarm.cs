using System.Collections;
using UnityEngine;

public class SignalAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.1f;
    [SerializeField] private AlarmTriggerer _alarmTriggerer;

    private float _targetVolume = 1f;
    private float _targetVolumeEnd = 0f;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    private void Start()
    {
        StartCoroutine(CheckSound());
    }

    private IEnumerator CheckSound()
    {
        while (enabled)
        {
            if (_alarmTriggerer.ReturnIsKickIn())
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            }
            else if (_alarmTriggerer.ReturnIsKickIn() == false && _audioSource.volume != 0)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolumeEnd, _fadeSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
