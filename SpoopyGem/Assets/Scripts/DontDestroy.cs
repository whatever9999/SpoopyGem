using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private DontDestroy instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
