using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]private int _health;
    [SerializeField]private Slider _healthSlider;

    void Start()
    {
        _healthSlider.maxValue = _health;
        _healthSlider.value = _health;
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        _healthSlider.value = _health;
        if ( _health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GetDamage(10);
        }
    }
}
