using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

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

        playerController.Shot += OnShooted;
    }

    private void OnHit(int damage) => Health -= damage;
    private void OnShooted() => Mana -= bullet.BulletCost;
    private void OnRegenerateMana(float speed) => Mana += Time.deltaTime * speed;

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
    }

    private void OnWastedLife()
    {
        healthSlider.value = healthSlider.maxValue;
        lifes.text = (Convert.ToInt32(lifes.text) - 1).ToString();
    }
}