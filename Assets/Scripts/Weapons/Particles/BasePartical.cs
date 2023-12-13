
using UnityEngine;

public class BasePartical : MonoBehaviour
{

    public Bullet Projectile;
    public float SlowDown;

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damageMulti;


    internal void ChangeDmgMilti(float dt)
    {
        _damageMulti = dt;
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        _speed -= Time.deltaTime * SlowDown/500;
        if (_speed < 0 | _lifeTime < 0)
        {
            if (Projectile.Effect != null) Destroy(Projectile.Effect.gameObject);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            Unit Attacked = collision.collider.GetComponent<Unit>();
            GiveDamage(Attacked);
            Influence(Attacked);
            if (Projectile.Effect != null) Projectile.Effect.gameObject.SetActive(true);
        }
        if (Projectile.Effect != null) Projectile.Effect.gameObject.SetActive(true);
        Destroy(gameObject);
    }


    private void GiveDamage(Unit taker)
    {
        (float, TypeElem) temp = Projectile.GiveOutLayerStats();
        taker.TakeDamege(temp.Item1 * _damageMulti, temp.Item2);
        temp = Projectile.GiveMidLayerStats();
        taker.TakeDamege(temp.Item1 * _damageMulti, temp.Item2);
        temp = Projectile.GiveInnLayerStats();
        taker.TakeDamege(temp.Item1 * _damageMulti, temp.Item2);
    }
    private void Influence(Unit Affected)
    {
        Projectile.GiveEffect(Affected);
    }

}
