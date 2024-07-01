using UnityEngine;

public class Flora_Wet_Dew_Effect : MonoBehaviour
{
    public bool Active_Wet_Dew_Effect = false;

    private void Start()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            if (Active_Wet_Dew_Effect == true)
            {
                if (GetComponent<Flora_Mask_Sart>() == null)
                {
                    Flora_Mask_Sart _Flora_Mask_Sart = gameObject.AddComponent(typeof(Flora_Mask_Sart)) as Flora_Mask_Sart;
                }
                if (GetComponent<SpriteMask>() == null)
                {
                    SpriteMask _SpriteMask = gameObject.AddComponent(typeof(SpriteMask)) as SpriteMask;
                }
            }
            if (Active_Wet_Dew_Effect == false)
            {
                if (GetComponent<Flora_Mask_Sart>() != null)
                {
                    Destroy(GetComponent<Flora_Mask_Sart>());
                }
                if (GetComponent<SpriteMask>() != null)
                {
                    Destroy(GetComponent<SpriteMask>());
                }
            }
        }
    }
}
