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
                Debug.Log("������: Flora_Mask_Sart - �� ��������� � ���� ����� SpriteRenderer. ���������� ��������� ����� SpriteRenderer � �������.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }
            if (GetComponent<SpriteMask>() != null)
            {
                _SpriteMask = GetComponent<SpriteMask>();
            }
            else
            {
                Debug.Log("������: Flora_Mask_Sart - �� ��������� � ���� ����� SpriteMask. ���������� ��������� ����� SpriteMask � �������.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }

            if (GetComponent<SpriteRenderer>() != null & GetComponent<SpriteMask>() != null)
            {
                _SpriteMask.sprite = _SpriteRenderer.sprite;
                Destroy(GetComponent<Flora_Mask_Sart>());
            }
            else
            {
                Debug.Log("������: Flora_Mask_Sart - ����������� ������.");
                Destroy(GetComponent<Flora_Mask_Sart>());
            }

        }
    }
}
