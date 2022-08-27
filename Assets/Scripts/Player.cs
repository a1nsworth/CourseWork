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

    [SerializeField] private int rangeX = 10;
    [SerializeField] private int rangeY = 10;
    [SerializeField] private float speedManaRegeneration = 1f;

    [SerializeField] private Bullet bullet;
    [SerializeField] private PlayerController playerController;

    private int _basicHealth;
    private int _basicLifes;
    private float _basicMana;

    private Rigidbody2D rb;
    private Animator animator;

    public event Action<int> Hit;
    public event Action Died;
    public event Action WastedLife;
    public event Action<float> RegenerateMana;

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

        playerController.Shot += OnShooted;
    }

    private void Update()
    {
        if (IsPossibleToRegenerateMana())
            RegenerateMana?.Invoke(speedManaRegeneration);

        if (IsInRange(rangeX, rangeY))
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

    public bool IsPossibleToShot() => Mana >= bullet.BulletCost;
    private bool IsPossibleToRegenerateMana() => Mana < _basicMana;

    private bool IsInRange(int x, int y)
    {
        var position = transform.position;
        return Math.Abs(position.x) > x && Math.Abs(position.y) > y;
    }

    private void OnHit(int damage) => Health -= damage;
    private void OnShooted() => Mana -= bullet.BulletCost;
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
}