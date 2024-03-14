using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    [SerializeField] private Slider _healthPlayerSlider;
    [SerializeField] private GameObject _gameOverUI;
    public float _playerHealth = 100;
    public float _damage;
    private bool _isHealth;
    public Animator _animator;

    private PlayerController playerController;
    private CameraController cameraController;
    private BulletCaster bulletCaster;
    private bool _isDie;
    private void Start()
    {
        _isDie = false;
        playerController = GetComponent<PlayerController>();
        cameraController = GetComponentInChildren<CameraController>();
        bulletCaster = GetComponent<BulletCaster>();
    }

    void Update()
    {
        _healthPlayerSlider.value = _playerHealth;
        Damage();
        RestartScene();

    }
    public void initializationDamage(float damage, bool isHealth)
    {
        _damage = damage;
        _isHealth = isHealth;
    }
    public void Damage()
    {
        if (_isHealth)
        {
            _playerHealth -= _damage * Time.deltaTime;
            if (_playerHealth <= 0) KillPlayery();
        }
    }
    private void KillPlayery()
    {
        _gameOverUI.SetActive(true);
        _isDie = true;
        AnimationDie();
    }
    public void AnimationDie()
    {
        _animator.SetTrigger("die");
    }
    private void RestartScene()
    {
        if (_isDie)
        {
            playerController.enabled = false;
            cameraController.enabled = false;
            bulletCaster.enabled = false;
            var bulletCasterStopShoot = transform.GetComponent<BulletCaster>();
            bulletCasterStopShoot._isShoot = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bulletCasterStopShoot._isShoot = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
