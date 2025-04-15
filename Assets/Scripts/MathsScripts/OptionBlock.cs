using UnityEngine;
using TMPro;

public class OptionBlock : MonoBehaviour
{
    [HideInInspector] public int optionValue;
    private GameManager gameManager;
    private TextMeshPro label;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        label = GetComponentInChildren<TextMeshPro>();
    }

    public void SetValue(int val)
    {
        optionValue = val;
        if (label != null)
            label.text = val.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.OnOptionHit(optionValue);
            Destroy(gameObject);
        }
    }
}
