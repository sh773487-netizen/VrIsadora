using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RitualManager : MonoBehaviour
{
    [Header("Objetos de Efectos (Inician desactivados)")]
    public GameObject malignantParticles;     
    public GameObject divineLightAndParticles;

    private int candlesPlaced = 0;
    private bool ritualStarted = false;

    void Start()
    {
        if (malignantParticles != null)
            malignantParticles.SetActive(false);

        if (divineLightAndParticles != null)
            divineLightAndParticles.SetActive(false);
    }

    public void CandleSnapped()
    {
        if (ritualStarted) return;

        candlesPlaced++;
        Debug.Log("Velas colocadas: " + candlesPlaced + "/6");

        if (candlesPlaced >= 6)
        {
            ritualStarted = true;
            StartCoroutine(RunRitualSequence());
        }
    }

    public void CandleUnsnapped()
    {
        if (ritualStarted) return;

        candlesPlaced = Mathf.Max(0, candlesPlaced - 1);
        Debug.Log("Vela retirada. Quedan: " + candlesPlaced + "/6");
    }

    IEnumerator RunRitualSequence()
    {
        Debug.Log("¡Ritual iniciado!");

        yield return new WaitForSeconds(1f);
        if (malignantParticles != null)
            malignantParticles.SetActive(true);

        yield return new WaitForSeconds(9f);
        if (divineLightAndParticles != null)
            divineLightAndParticles.SetActive(true);

        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}