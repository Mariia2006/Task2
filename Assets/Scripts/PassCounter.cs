using UnityEngine;

public class PassCounter : MonoBehaviour
{
    public int passCount = 0;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        passCount++;
        Debug.Log("Разів пролетів крізь тригер: " + passCount);
    }
}
