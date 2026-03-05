using UnityEngine;

public class SignControll : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.1f; 

    private float _targetVolume = 1f;
    private float _targetVolumeEnd = 0f;
    private bool _isKickIn = false;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
    }

    private void Update()
    {
        if (_isKickIn)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
        }
        else if (_isKickIn == false && _audioSource.volume != 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolumeEnd, _fadeSpeed * Time.deltaTime);
        }

        Debug.Log(_audioSource.volume);
        Debug.Log(_isKickIn);
    }

    private void OnTriggerEnter2D(Collider2D hero)
    {
        if (hero.GetComponent<Hero>())
        {
            _audioSource.Play();
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
}
