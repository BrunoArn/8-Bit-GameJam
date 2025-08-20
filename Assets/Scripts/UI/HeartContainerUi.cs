using UnityEngine;
using UnityEngine.UI;

public class HeartContainerUi : MonoBehaviour
{
    [SerializeField] Image heartFill;

    public void HeartFill(bool enable)
    {
        heartFill.enabled = enable;
    }
}
