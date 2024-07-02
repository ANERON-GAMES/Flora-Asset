using UnityEngine;

public class Flora_Random_Sprite_Type : MonoBehaviour
{
    public Sprite[] _SpriteRenderer;

    private int Length_SpriteRenderer;
    private int Random_SpriteRenderer;
    private SpriteRenderer _SpriteRenderer_obj;
    private void Start()
    {
        Length_SpriteRenderer = _SpriteRenderer.Length;
        if (Length_SpriteRenderer == 0)
        {
            Debug.Log("������: Flora_Random_Sprite_Type - ��������� � ���� ������ ������. ���������� ��������� ������ ���� �������������� �������.");
            Destroy(GetComponent<Flora_Random_Sprite_Type>());
        }
        if (Length_SpriteRenderer != 0)
        {
            Random_SpriteRenderer = Random.Range(0, Length_SpriteRenderer);
            if (GetComponent<SpriteRenderer>() != null)
            {
                _SpriteRenderer_obj = GetComponent<SpriteRenderer>();
                _SpriteRenderer_obj.sprite = _SpriteRenderer[Random_SpriteRenderer];
            }
            else
            {
                Debug.Log("������: Flora_Random_Sprite_Type - �� ��������� � ���� ����� SpriteRenderer. ���������� ��������� ����� SpriteRenderer � ������� � ��������.");
            }
        }
    }
}
