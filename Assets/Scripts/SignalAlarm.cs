using System.Collections;
using UnityEngine;

public class SignalAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.1f;
    [SerializeField] private AlarmTriggerer _alarmTriggerer;

    private float _targetVolume = 1f;
    private float _targetVolumeEnd = 0f;

    private bool _isKickIn;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _alarmTriggerer.IsEnteringTrigger += Initialise;
    }

    private void Start()
    {
        StartCoroutine(CheckSound());
    }

    private void OnDisable()
    {
        _alarmTriggerer.IsEnteringTrigger -= Initialise;
    }

    private void Initialise(bool isKickIn)
    {
        _isKickIn = isKickIn;
    }

    private IEnumerator CheckSound()
    {
        while (enabled)
        {
            if (_isKickIn)
            {
                ChangeVolume(_targetVolume);
            }
            else if (_isKickIn == false && _audioSource.volume != 0)
            {
                ChangeVolume(_targetVolumeEnd);
            }

            yield return null;
        }
    }

    private void ChangeVolume(float targetVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);
    }
}
