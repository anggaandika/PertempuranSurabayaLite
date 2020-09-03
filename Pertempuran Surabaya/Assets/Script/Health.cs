using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int nyawaAwal = 5;

    private int currentNyawa;

    private void OnEnable()
    {
        currentNyawa = nyawaAwal;
    }

    public void TakeDamage(int banyaknyaDamage)
    {
        currentNyawa -= banyaknyaDamage;

        if (currentNyawa <= 0)
            Mati();
    }

    private void Mati()
    {
        gameObject.SetActive(false);
    }
}
