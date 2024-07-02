using UnityEngine;

public class Flora_Rain_Effect : MonoBehaviour
{
    public Camera _Camera;
    public Flora_Effect_Area _Flora_Effect_Area;
    private ParticleSystem _Flora_Rain_Effect_ParticleSystem;

    public float Rain_Coverage = 3;
    public float Increase_Flora_Rain_position_Y = 0;
    public float Increase_Flora_Rain_position_X = 0;
    public bool Automatic_Increase_Rain_Deviation_X = true;
    public float Wind_Speed_Multiplier = 2F;
    public enum myEnum
    {
        Minimum,
        Optimal,
        Realistic,
        Incredible
    }
    public myEnum Quality_Rain = myEnum.Minimum;
    public bool Quality_Drops = true;
    private float default_Flora_Rain_position_Y;
    private float default_Scale_Camera;

    private float rain_zone_multiplier;
    private float rain_zone_multiplier_tipe_2;

    private float Rain_pos_x;

    private float rain_Rotation;
    private void Start()
    {
        if (_Camera == null)
        {
            Debug.Log("Скрипт: Flora_Rain_Effect - не обнаружил у себя форму Camera. Пожалуйста укажите форму Camera в скрипте.");
            Destroy(GetComponent<Flora_Rain_Effect>());
        }
        if (_Flora_Effect_Area == null)
        {
            Debug.Log("Скрипт: Flora_Rain_Effect - не обнаружил у себя форму Flora_Effect_Area. Пожалуйста укажите форму Flora_Effect_Area в скрипте.");
            Destroy(GetComponent<Flora_Rain_Effect>());
        }
        if (default_Scale_Camera != _Camera.orthographicSize)
        {
            default_Scale_Camera = _Camera.orthographicSize;
        }
    }

    private void Update()
    {
        if (rain_zone_multiplier != _Flora_Effect_Area.Real_Force_Area)
        {
            rain_zone_multiplier = _Flora_Effect_Area.Real_Force_Area;
            if (rain_zone_multiplier < 0)
            {
                rain_zone_multiplier *= -1;
            }
        }
        if (rain_zone_multiplier_tipe_2 != _Flora_Effect_Area.Real_Force_Area)
        {
            rain_zone_multiplier_tipe_2 = _Flora_Effect_Area.Real_Force_Area;
        }
        if (rain_Rotation != rain_zone_multiplier_tipe_2)
        {
            rain_Rotation = rain_zone_multiplier_tipe_2;
        }
        if (default_Flora_Rain_position_Y != _Camera.transform.position.y)
        {
            default_Flora_Rain_position_Y = _Camera.transform.position.y;
        }

        if (_Flora_Rain_Effect_ParticleSystem.shape.scale != new Vector3(_Flora_Rain_Effect_ParticleSystem.shape.scale.x, _Flora_Rain_Effect_ParticleSystem.shape.scale.y,  rain_zone_multiplier + ((_Camera.orthographicSize*4) + Rain_Coverage)))
        {
            var _Flora_Rain = _Flora_Rain_Effect_ParticleSystem.shape;
            _Flora_Rain.scale = new Vector3(_Flora_Rain_Effect_ParticleSystem.shape.scale.x, _Flora_Rain_Effect_ParticleSystem.shape.scale.y, rain_zone_multiplier + ((_Camera.orthographicSize *4) + Rain_Coverage));
            _Flora_Rain.position = new Vector3(((rain_zone_multiplier_tipe_2 / ((_Flora_Effect_Area.Random_Force_Area.x + _Flora_Effect_Area.Random_Force_Area.y)/ _Flora_Effect_Area.Smoothness))) * -1, _Flora_Rain.position.y, _Flora_Rain.position.z);
        }
        if (_Flora_Rain_Effect_ParticleSystem.transform.position.y != (default_Flora_Rain_position_Y + Increase_Flora_Rain_position_Y) + (_Camera.orthographicSize - default_Scale_Camera))
        {
            _Flora_Rain_Effect_ParticleSystem.transform.position = new Vector3(_Flora_Rain_Effect_ParticleSystem.transform.position.x, (default_Flora_Rain_position_Y + Increase_Flora_Rain_position_Y) + (_Camera.orthographicSize - default_Scale_Camera), _Flora_Rain_Effect_ParticleSystem.transform.position.z);
        }
        if (rain_Rotation > 0.75F)
        {
            rain_Rotation = 0.57F;
        }
        if (rain_Rotation < -0.75F)
        {
            rain_Rotation = -0.75F;
        }
        if (Rain_pos_x != _Flora_Effect_Area.Real_Force_Area * -1)
        {
            Rain_pos_x = _Flora_Effect_Area.Real_Force_Area * -1;
        }
        if (_Flora_Rain_Effect_ParticleSystem.startRotation != rain_Rotation * -1)
        {
            _Flora_Rain_Effect_ParticleSystem.startRotation = rain_Rotation * -1;
        }
        if (_Flora_Rain_Effect_ParticleSystem.startSpeed != _Flora_Effect_Area.Real_Force_Area * Wind_Speed_Multiplier)
        {
            _Flora_Rain_Effect_ParticleSystem.startSpeed = _Flora_Effect_Area.Real_Force_Area * Wind_Speed_Multiplier;
        }

        if (Automatic_Increase_Rain_Deviation_X == false)
        {
            if (_Flora_Rain_Effect_ParticleSystem.transform.position.x != Rain_pos_x + Increase_Flora_Rain_position_X)
            {
                _Flora_Rain_Effect_ParticleSystem.transform.position = new Vector3(Rain_pos_x + Increase_Flora_Rain_position_X, _Flora_Rain_Effect_ParticleSystem.transform.position.y, _Flora_Rain_Effect_ParticleSystem.transform.position.z);
            }
        }
        if (Automatic_Increase_Rain_Deviation_X == true)
        {
            if (_Flora_Rain_Effect_ParticleSystem.transform.position.x != Rain_pos_x * Increase_Flora_Rain_position_X)
            {
                _Flora_Rain_Effect_ParticleSystem.transform.position = new Vector3(Rain_pos_x * Increase_Flora_Rain_position_X, _Flora_Rain_Effect_ParticleSystem.transform.position.y, _Flora_Rain_Effect_ParticleSystem.transform.position.z);
            }
        }

    }
    private void OnValidate()
    {
        if (GetComponent<ParticleSystem>() != null)
        {
            _Flora_Rain_Effect_ParticleSystem = GetComponent<ParticleSystem>();
        }
        else
        {
            Debug.Log("Скрипт: Flora_Rain_Effect - не обнаружил у себя форму ParticleSystem. Пожалуйста примените форму ParticleSystem к объекту с скриптом.");
            return;
        }

        if (Quality_Rain == myEnum.Minimum)
        {
            var emission = _Flora_Rain_Effect_ParticleSystem.emission;
            emission.enabled = true;
            emission.rateOverTime = 50.0f;
        }
        else if (Quality_Rain == myEnum.Optimal)
        {
            var emission = _Flora_Rain_Effect_ParticleSystem.emission;
            emission.enabled = true;
            emission.rateOverTime = 200.0f;
        }
        else if (Quality_Rain == myEnum.Realistic)
        {
            var emission = _Flora_Rain_Effect_ParticleSystem.emission;
            emission.enabled = true;
            emission.rateOverTime = 1000.0f;
        }
        else if (Quality_Rain == myEnum.Incredible)
        {
            var emission = _Flora_Rain_Effect_ParticleSystem.emission;
            emission.enabled = true;
            emission.rateOverTime = 5000.0f;
        }

        if (Quality_Drops == true)
        {
            var _minKillSpeed = _Flora_Rain_Effect_ParticleSystem.collision;
            _minKillSpeed.minKillSpeed = 0;
        }
        else if (Quality_Drops == false)
        {
            var _minKillSpeed = _Flora_Rain_Effect_ParticleSystem.collision;
            _minKillSpeed.minKillSpeed = 20;
        }

    }
}
