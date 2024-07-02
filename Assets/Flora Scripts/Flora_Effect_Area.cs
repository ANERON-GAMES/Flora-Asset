using System.Collections;
using UnityEngine;

public class Flora_Effect_Area : MonoBehaviour
{
    private AreaEffector2D _AreaEffector2D;

    private float Force_Area = 1;

    public bool Active_Wind_Swing_Effect;
    public int Start_CD_Wind_Swing_Effect = 5;
    private int CD_Wind_Swing_Effect;
    public Vector2 Random_Force_Area;
    public float Smoothness = 2;
    private float Time_Update_Force_Area = 1;

    private float _Random;
    public float Real_Force_Area;
    private float Speed_Real_Force_Area = 1;

    public bool Active_forceAngle;
    public bool Active_forceMagnitude = true;
    public bool Active_forceVariation;
    private void Start()
    {
        CD_Wind_Swing_Effect = Start_CD_Wind_Swing_Effect;

        if (GetComponent<AreaEffector2D>() == null)
        {
            Debug.Log("Скрипт: Flora_Effect_Area - не обнаружил у себя форму AreaEffector2D. Пожалуйста примените форму AreaEffector2D к объекту с скриптом.");
            Destroy(GetComponent<Flora_Effect_Area>());
        }
        if (GetComponent<AreaEffector2D>() != null)
        {
            _AreaEffector2D = GetComponent<AreaEffector2D>();
            _AreaEffector2D.forceMagnitude = Force_Area;
            StartCoroutine("Effect_Area");
        }
        if (Random_Force_Area.x + Random_Force_Area.y == 0)
        {
            Debug.Log("Скрипт: Flora_Effect_Area - обнаружил у себя пустую форму Random_Force_Area. Пожалуйста заполните форму Random_Force_Area у объекта с скриптом.");
            Destroy(GetComponent<Flora_Effect_Area>());
        }
        if (Smoothness == 0)
        {
            Debug.Log("Скрипт: Flora_Effect_Area - обнаружил у себя пустую форму Smoothness. Пожалуйста заполните форму Smoothness у объекта с скриптом или поставьте значение: (1) что бы полностью отключить данный эффект.");
            Destroy(GetComponent<Flora_Effect_Area>());
        }
    }
    private void Update()
    {
        if (Smoothness == 0)
        {
            Debug.Log("Скрипт: Flora_Effect_Area - обнаружил у себя пустую форму Smoothness. Пожалуйста заполните форму Smoothness у объекта с скриптом или поставьте значение: (1) что бы полностью отключить данный эффект.");
            return;
        }
        if (Speed_Real_Force_Area != ((Random_Force_Area.x + Random_Force_Area.y) / Smoothness))
        {
            Speed_Real_Force_Area = ((Random_Force_Area.x + Random_Force_Area.y) / Smoothness);
            if (Speed_Real_Force_Area <= 0)
            {
                Speed_Real_Force_Area = Speed_Real_Force_Area * (-1);
            }
        }
        if (Real_Force_Area != Force_Area)
        {
            if (Real_Force_Area < Force_Area)
            {
                Real_Force_Area += Speed_Real_Force_Area * Time.deltaTime;
            }
            if (Real_Force_Area > Force_Area)
            {
                Real_Force_Area -= Speed_Real_Force_Area * Time.deltaTime;
            }
        }

        if (Active_forceAngle == true)
        {
            if (_AreaEffector2D.forceAngle != Real_Force_Area)
            {
                _AreaEffector2D.forceAngle = Real_Force_Area;
            }
        }
        else
        {
            if (_AreaEffector2D.forceAngle != 0)
            {
                _AreaEffector2D.forceAngle = 0;
            }
        }
        if (Active_forceMagnitude == true)
        {
            if (_AreaEffector2D.forceMagnitude != Real_Force_Area)
            {
                _AreaEffector2D.forceMagnitude = Real_Force_Area;
            }
        }
        else
        {
            if (_AreaEffector2D.forceMagnitude != 0)
            {
                _AreaEffector2D.forceMagnitude = 0;
            }
        }
        if (Active_forceVariation == true)
        {
            if (_AreaEffector2D.forceVariation != Real_Force_Area)
            {
                _AreaEffector2D.forceVariation = Real_Force_Area;
            }
        }
        else
        {
            if (_AreaEffector2D.forceVariation != 0)
            {
                _AreaEffector2D.forceVariation = 0;
            }
        }
    }

    private IEnumerator Effect_Area()
    {
        yield return new WaitForSeconds(Time_Update_Force_Area);
        _Random = Random.Range(Random_Force_Area.x, Random_Force_Area.y);
        if (Active_Wind_Swing_Effect == true)
        {
            if (CD_Wind_Swing_Effect > 0)
            {
                CD_Wind_Swing_Effect -= 1;
                Force_Area = _Random;

            }
            if (CD_Wind_Swing_Effect <= 0)
            {
                Force_Area = _Random * -1;
                CD_Wind_Swing_Effect = Start_CD_Wind_Swing_Effect;
            }
        }
        if (Active_Wind_Swing_Effect == false)
        {
            Force_Area = _Random;
        }

        StartCoroutine("Effect_Area");
    }
}
