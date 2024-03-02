using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        _healthPlayerSlider.value = _playerHealth;
        Damage();
        RestartScene();
    }
    public void initializationDamage(float damage , bool isHealth)
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
    private void KillPlayery() => _gameOverUI.SetActive(true);
    private void RestartScene()
    {
        if (_gameOverUI.activeSelf)
        {
            Time.timeScale = 0f;
            var bulletCasterStopShoot = transform.GetComponent<BulletCaster>();
            bulletCasterStopShoot._isShoot = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                bulletCasterStopShoot._isShoot = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
