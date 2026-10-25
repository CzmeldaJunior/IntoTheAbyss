using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image background;
    public Image preHp;
    public Image mainHp;


    public void SetHealth(float currentHp, float maxHp)
    {
        StartCoroutine(LerpHealth(currentHp / maxHp));
    }

    private IEnumerator LerpHealth(float target)
    {
        while (mainHp.fillAmount >= target)
        {
            mainHp.fillAmount = Mathf.MoveTowards(
                mainHp.fillAmount,
                target,
                5f * Time.deltaTime
            );

            yield return null;
        }
    }
}
