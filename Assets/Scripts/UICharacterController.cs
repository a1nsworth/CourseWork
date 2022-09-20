using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterController : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider manaSlider;
    [SerializeField] private TextMeshProUGUI lifes;
    [SerializeField] private TextMeshProUGUI nickname;
    [SerializeField] private GameObject imageLife;
    [SerializeField] private GameObject imageDie;

    [SerializeField] private Player player;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Bullet supperBullet;
    [SerializeField] private PlayerController playerController;

    public float Health
    {
        get => healthSlider.value;
        set => healthSlider.value = value;
    }

    public float Mana
    {
        get => manaSlider.value;
        set => manaSlider.value = value;
    }

    public string Life
    {
        get => lifes.text;
        set => lifes.text = value;
    }

    public string Nickname
    {
        get => nickname.text;
        set => nickname.text = value;
    }

    private void Start()
    {
        Life = player.Lifes.ToString();
        manaSlider.maxValue = player.Mana;
        healthSlider.maxValue = player.Health;

        player.Hit += OnHit;
        player.Died += OnDied;
        player.WastedLife += OnWastedLife;
        player.RegenerateMana += OnRegenerateMana;
        player.BonusHP += OnGeneratedFullHP;
        player.BonusMana += OnGeneratedFullMana;
        player.BonusLife += OnBoostedLife;

        playerController.BasicShot += OnSimpleShooted;
        playerController.SupperShot += OnSupperShooted;
    }

    private void OnHit(int damage) => Health -= damage;
    private void OnSimpleShooted() => Mana -= bullet.BulletCost;
    private void OnSupperShooted() => Mana -= supperBullet.BulletCost;
    private void OnRegenerateMana(float speed) => Mana += Time.deltaTime * speed;

    private void OnGeneratedFullHP() => Health = healthSlider.maxValue;
    private void OnGeneratedFullMana() => Mana = manaSlider.maxValue;
    private void OnBoostedLife() => Life = (Convert.ToInt32(lifes.text) + 1).ToString();

    private void OnDied()
    {
        imageLife.SetActive(false);
        imageDie.SetActive(true);

        Life = "0";
        Health = 0;

        player.Hit -= OnHit;
        player.Died -= OnDied;
        player.WastedLife -= OnWastedLife;
        player.RegenerateMana -= OnRegenerateMana;
        player.BonusHP -= OnGeneratedFullHP;
        player.BonusMana -= OnGeneratedFullMana;
        player.BonusLife -= OnBoostedLife;
    }

    private void OnWastedLife()
    {
        healthSlider.value = healthSlider.maxValue;
        Life = (Convert.ToInt32(lifes.text) - 1).ToString();
    }
}