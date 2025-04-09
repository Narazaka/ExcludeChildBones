using UnityEngine;
using VRC.SDKBase;

namespace Narazaka.VRChat.ExcludeChildBones
{
    public class ExcludeChildBones : MonoBehaviour, IEditorOnly
    {
        [SerializeField] public Transform[] KeepTransforms;
        [Tooltip("Default: parent")]
        [SerializeField] public Transform MoveTo;
    }
}
