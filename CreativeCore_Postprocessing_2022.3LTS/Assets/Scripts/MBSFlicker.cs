using UnityEngine;

public class MBSFlicker : MonoBehaviour
{
   
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float vStopTime;
    [SerializeField] Vector3 vStart;
    [SerializeField] Vector3 vEnd;
    [SerializeField] float vVary;
    [SerializeField] float vNewTime;
    [SerializeField] float vTimeVaryLow;
    [SerializeField] float vTimeVaryHigh;
    [SerializeField] float vFlickerDurataion;
    [SerializeField] float vStartRange;
    [SerializeField] Transform gWeather;


    private void Start()
    {
        

    }

    private void Update()
    {
       if (Time.time > vNewTime)
        {
            vNewTime = Time.time + Random.Range(vTimeVaryLow,vTimeVaryHigh);
            vStopTime = Time.time + vFlickerDurataion;

            vStart = gWeather.position + new Vector3(Random.Range(-vStartRange, vStartRange), 0, Random.Range(-vStartRange, vStartRange));

            vEnd = vStart;
            vEnd.y = 0; 

        }
        
        
        if (Time.time < vStopTime)
        {
            Debug.Log("Flicker");
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, vStart);
            lineRenderer.SetPosition(10, vEnd);

            for (int i = 1; i < 10; i++)
            {
                lineRenderer.SetPosition(i, ((10 - i) * vStart) / 10 + (i * vEnd) / 10 + vVary *
                    new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1.0f), Random.Range(-1f, 1f)));

            }



        }

        else
        {
            lineRenderer.enabled = false;
        }

    }



    public void FnFlicker(float vEndTime, Vector3 vStartPos, Vector3 vEndPos,float vVariance)
    {
        vStopTime = vEndTime;
        vStart = vStartPos;
        vEnd = vEndPos;
        vVary = vVariance;

    }



}
