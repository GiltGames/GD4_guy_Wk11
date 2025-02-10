using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Fade : MonoBehaviour
{

    public Volume gVol;
    [SerializeField] Vignette gVig;
    [SerializeField] ColorAdjustments gColorAdj;
    [SerializeField] float vVigStart;
    [SerializeField] float vVigEnd;
    [SerializeField] float vSaturationSt;
    [SerializeField] float vSatuationEnd;
    [SerializeField] float vFadeTime=1;
    [SerializeField] float vVigTmp;
    [SerializeField] float vSatTmp;
    [SerializeField] float vErrorAllowance = .05f;
    [SerializeField] bool isFading;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gVol = GetComponent<Volume>();
        gVol.profile.TryGet(out gVig);
        gVol.profile.TryGet(out gColorAdj);

vSatuationEnd = gColorAdj.saturation.value;
        vVigEnd = gVig.intensity.value;
        isFading = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))

                {

            vSatTmp = vSaturationSt;
            vVigTmp = vVigStart;
            isFading = true;



        }

        if (isFading)
        {
            Fadeback();
        }


    }


    void Fadeback()

    {
        if (Mathf.Abs(vSatTmp - vSatuationEnd) > vErrorAllowance)
        {

            vSatTmp += (vFadeTime * -(vSaturationSt - vSatuationEnd) * Time.deltaTime);
            vVigTmp += (vFadeTime * -(vVigStart - vVigEnd) * Time.deltaTime);
            gVig.intensity.value = vVigTmp;
            gColorAdj.saturation.value = vSatTmp;

            

           
        }
        else
        {
            isFading = false;
        }
    }

}
