using UnityEngine;

public class Flora_Settings_Dew_Graphs : MonoBehaviour
{
    public enum myEnum
    {
        Disabled,
        Minimum,
        Realistic
    }
    public myEnum Quality_Settings_Dew_Graphs = myEnum.Minimum;

    private Flora_Effect_Dew[] _Flora_Effect_Dew_Massif;

    private void OnValidate()
    {
        _Flora_Effect_Dew_Massif = FindObjectsOfType(typeof(Flora_Effect_Dew)) as Flora_Effect_Dew[];

        if (_Flora_Effect_Dew_Massif.Length != 0)
        {
            for (int i = 0; i < _Flora_Effect_Dew_Massif.Length; i++)
            {
                _Flora_Effect_Dew_Massif[i].Set_myEnum(Quality_Settings_Dew_Graphs.ToString());
            }
        }
        else
        {
            Debug.Log("Скрипт: Flora_Settings_Dew_Graphs - не обнаружил у себя форму _Flora_Effect_Dew_Massif. На сцене нет не одного объекта типа Flora_Effect_Dew");
            return;
        }
    }
}
