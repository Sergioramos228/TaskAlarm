using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _input = new();
    [SerializeField] private UnityEvent _output = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _input.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _output.Invoke();
        }
    }
}
