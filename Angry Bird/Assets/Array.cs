using UnityEngine;

public class Array : MonoBehaviour
{

    int a = 5;

    public int[] myArray = new int[5];

    public int[] MyArray2 = { 12, 76, 8, 10 };

    // Start is called before the first frame update
    void Start()
    {
        a = 5;

       foreach (int i in MyArray2)
        {
            Debug.Log(i);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void newFunction(int a , int u, float f)
    {
        Debug.Log("Hello");
    }

    public void newFuntion ()
    {
        Debug.Log("Hi there");
    }
}
