using UnityEngine;

public class Flora_Mask_Sart : MonoBehaviour
{
    private SpriteRenderer _SpriteRenderer;
    private SpriteMask _SpriteMask;

    private float time_cd = 1;
    private void Update()
    {
        if (time_cd < 1)
        {
            time_cd += 1 * Time.deltaTime;
        }
        else
        {
            if (GetComponent<SpriteRenderer>() != null)
            {
                _SpriteRenderer = GetComponent<SpriteRenderer>();
            }
            else
            {
                Debug.Log("Скрипт: Flora_Mask_Sart - не обнаружил у себя форму SpriteRenderer. Пожалуйста примените форму SpriteRenderer к объекту.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }
            if (GetComponent<SpriteMask>() != null)
            {
                _SpriteMask = GetComponent<SpriteMask>();
            }
            else
            {
                Debug.Log("Скрипт: Flora_Mask_Sart - не обнаружил у себя форму SpriteMask. Пожалуйста примените форму SpriteMask к объекту.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }

            if (GetComponent<SpriteRenderer>() != null & GetComponent<SpriteMask>() != null)
            {
                _SpriteMask.sprite = _SpriteRenderer.sprite;
                Destroy(GetComponent<Flora_Mask_Sart>());
            }
            else
            {
                Debug.Log("Скрипт: Flora_Mask_Sart - Критическая ошибка.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }

        }
    }
}
