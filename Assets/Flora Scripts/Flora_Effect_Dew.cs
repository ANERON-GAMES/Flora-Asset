using UnityEngine;

public class Flora_Effect_Dew : MonoBehaviour
{
    public ParticleSystem _ParticleSystem_Effect_Dew;

    public enum _myEnum
    {
        Disabled,
        Minimum,
        Realistic
    }
    public _myEnum Quality_Dew = _myEnum.Minimum;
    private void Start()
    {
        if (GetComponent<ParticleSystem>() != null)
        {
            _ParticleSystem_Effect_Dew = GetComponent<ParticleSystem>();
        }
        else
        {
            Debug.Log("������: Flora_Effect_Dew - �� ��������� � ���� ����� ParticleSystem. ���������� ��������� ����� ParticleSystem � �������.");
            Destroy(GetComponent<Flora_Effect_Dew>());
        }
    }

    public void Set_myEnum(string Set)
    {
        if (Set == "Disabled")
        {
            Quality_Dew = _myEnum.Disabled;
        }
        else if (Set == "Minimum")
        {
            Quality_Dew = _myEnum.Minimum;
        }
        else if (Set == "Realistic")
        {
            Quality_Dew = _myEnum.Realistic;
        }
        else
        {
            Debug.Log("������: Flora_Effect_Dew - ��������� � ���� �� ������ ����� Set. ���������� ��������� ������ ����� Set � �������.");
        }
        OnValidate();
    }
    private void OnValidate()
    {
        if (_ParticleSystem_Effect_Dew == null)
        {
            if (GetComponent<ParticleSystem>() != null)
            {
                _ParticleSystem_Effect_Dew = GetComponent<ParticleSystem>();
            }
            else
            {
                Debug.Log("������: Flora_Effect_Dew - �� ��������� � ���� ����� ParticleSystem. ���������� ��������� ����� ParticleSystem � �������.");
                return;
            }
        }

        if (Quality_Dew == _myEnum.Disabled)
        {
            if (_ParticleSystem_Effect_Dew != null)
            {
                var emission = _ParticleSystem_Effect_Dew.emission;
                emission.enabled = false;
            }
        }
        if (Quality_Dew == _myEnum.Minimum)
        {
            if (_ParticleSystem_Effect_Dew != null)
            {
                var emission = _ParticleSystem_Effect_Dew.emission;
                emission.enabled = true;
                emission.rateOverTime = 30;
            }
        }
        if (Quality_Dew == _myEnum.Realistic)
        {
            if (_ParticleSystem_Effect_Dew != null)
            {
                var emission = _ParticleSystem_Effect_Dew.emission;
                emission.enabled = true;
                emission.rateOverTime = 100;
            }
        }
    }
}
