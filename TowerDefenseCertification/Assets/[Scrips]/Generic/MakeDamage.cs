using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    [SerializeField] private int _powerDamage = 10;
    [SerializeField] private string _tagToCompare = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tagToCompare))
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.ReceiveDamage(_powerDamage);
            }
        }
    }
}
