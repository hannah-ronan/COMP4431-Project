using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{

    public static DoNotDestroy instance;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
