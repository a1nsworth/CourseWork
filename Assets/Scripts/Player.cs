using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [field: SerializeField] public int Health { get; set; } = 100;
    [field: SerializeField] public int Lifes { get; set; } = 1;
    [field: SerializeField] public float Mana { get; set; } = 100;

    [SerializeField] private float speedManaRegeneration = 1f;

    [SerializeField] private Bullet bullet;
    [SerializeField] private Bullet supperBullet;
    [SerializeField] private PlayerController playerController;

    private int _basicHealth;
    private int _basicLifes;
    private float _basicMana;

    private readonly int _rangeY = -10;

    private Rigidbody2D rb;
    private Animator animator;

    public event Action<int> Hit;
    public event Action Died;
    public event Action WastedLife;
    public event Action<float> RegenerateMana;
    public event Action BonusHP;
    public event Action BonusMana;
    public event Action BonusLife;

    private void Start()
    {
        _basicHealth = Health;
        _basicLifes = Lifes;
        _basicMana = Mana;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Hit += OnHit;
        Died += OnDied;
        WastedLife += OnWastedLife;
        RegenerateMana += OnRegenerateMana;

        playerController.BasicShot += OnSimpeShooted;
        playerController.SupperShot += OnSupperShooted;
    }

    private void Update()
    {
        if (IsPossibleToRegenerateMana())
            RegenerateMana?.Invoke(speedManaRegeneration);

        if (IsInRange())
            Died?.Invoke();
    }

    public void GetDamage(int damage)
    {
        if (Health <= damage)
        {
            if (Lifes <= 1)
                Died?.Invoke();
            else
                WastedLife?.Invoke();
        }
        else
        {
            Hit?.Invoke(damage);
            animator.SetTrigger("Hurt");
        }

        Debug.Log(Health);
    }

    public bool IsPossibleToBasicShot() => Mana >= bullet.BulletCost;
    public bool IsPossibleToSupperShot() => Mana >= supperBullet.BulletCost;
    public bool IsPossibleToRegenerateMana() => Mana < _basicMana;

    private bool IsInRange()
    {
        var position = transform.position;
        return position.y < _rangeY;
    }

    private void OnHit(int damage) => Health -= damage;
    private void OnSimpeShooted() => Mana -= bullet.BulletCost;
    private void OnSupperShooted() => Mana -= supperBullet.BulletCost;
    private void OnRegenerateMana(float speed) => Mana += Time.deltaTime * speed;

    private void OnWastedLife()
    {
        Health = _basicHealth;
        Lifes--;
    }

    public void OnDied()
    {
        animator.SetTrigger("Die");

        SelectWinner(gameObject);
        Destroy(gameObject);

        Hit -= OnHit;
        Died -= OnDied;
        WastedLife -= OnWastedLife;
        RegenerateMana -= OnRegenerateMana;
    }

    private void SelectWinner(GameObject gameObject)
    {
        if (gameObject.name == "character1")
            EndBar.victoryState = EndBar.VictoryState.Player2;
        else if (gameObject.name == "character2")
            EndBar.victoryState = EndBar.VictoryState.Player1;

        EndGameController.OnEndGame();
    }

    public void GenerateFullHP()
    {
        Health = _basicHealth;
        BonusHP?.Invoke();
    }

    public void GenerateFullMana()
    {
        Mana = _basicMana;
        BonusMana?.Invoke();
    }

    public void LifeBoost()
    {
        Lifes++;
        BonusLife?.Invoke();
    }
}