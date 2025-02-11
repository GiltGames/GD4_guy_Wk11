using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] float vMove=3;
    [SerializeField] float vTurn = 60;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float Movex = Input.GetAxis("Vertical");
        float Turn = Input.GetAxis("Horizontal");

        transform.Translate (Movex *vMove,0,0);
        transform.Rotate(0, Turn * vTurn, 0);
        

    }
}
