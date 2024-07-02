using UnityEngine;

public class Flora_Random_Material_Type : MonoBehaviour
{
    public Material[] _Material;

    private int Length_Material;
    private int Random_Material;
    private void Start()
    {
        Length_Material = _Material.Length;
        if (Length_Material == 0)
        {
            Debug.Log("������: Flora_Random_Material_Type - ��������� � ���� ������ ������. ���������� ��������� ������ ���� �������������� �������.");
            Destroy(GetComponent<Flora_Random_Material_Type>());
        }
        if (Length_Material != 0)
        {
            Random_Material = Random.Range(0, Length_Material);
            if (GetComponent<SpriteRenderer>().material != null)
            {
                GetComponent<SpriteRenderer>().material = _Material[Random_Material];
            }
            else
            {
                Debug.Log("������: Flora_Random_Material_Type - �� ��������� � ���� ����� SpriteRenderer.Material. ���������� ��������� ����� SpriteRenderer.Material � ������� � ��������.");
            }
        }
    }
}
