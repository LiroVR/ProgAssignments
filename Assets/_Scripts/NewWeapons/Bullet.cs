using UnityEngine;

namespace ScriptableObjects
{

    public enum EFireMode
    {
        Single,
        Burst,
        Automatic
    }
    [CreateAssetMenu(menuName = "Shoot/Bullet", fileName = "Bullet", order = 1)]
    public class Bullet : ScriptableObject
    {
        [SerializeField] public EFireMode fireMode;
    }
}
