using System.Collections.Generic;
using UnityEngine;
using nadena.dev.ndmf;
using System.Linq;
using UnityEditor;
using UnityEngine.Animations;
using nadena.dev.ndmf.animator;

[assembly: ExportsPlugin(typeof(Narazaka.VRChat.ExcludeChildBones.Editor.ExcludeChildBonesPlugin))]

namespace Narazaka.VRChat.ExcludeChildBones.Editor
{
    public class ExcludeChildBonesPlugin : Plugin<ExcludeChildBonesPlugin>
    {
        public override string DisplayName => "Exclude Child Bones (for old DynamicBones)";
        public override string QualifiedName => "net.narazaka.vrchat.exclude-child-bones";
        protected override void Configure()
        {
            InPhase(BuildPhase.Transforming).AfterPlugin("nadena.dev.modular-avatar").WithRequiredExtension(typeof(AnimatorServicesContext), seq => seq.Run("ExcludeChildBones", Pass));
        }

        void Pass(BuildContext ctx)
        {
            var excludeChildBones = ctx.AvatarRootObject.GetComponentsInChildren<ExcludeChildBones>(true);
            foreach (var excludeChildBone in excludeChildBones)
            {
                Process(ctx, excludeChildBone);
                Object.DestroyImmediate(excludeChildBone);
            }
        }

        void Process(BuildContext ctx, ExcludeChildBones excludeChildBones)
        {
            var moveTo = excludeChildBones.MoveTo;
            if (moveTo == null) moveTo = excludeChildBones.transform.parent;
            var KeepTransforms = new HashSet<Transform>(excludeChildBones.KeepTransforms == null ? Enumerable.Empty<Transform>() : excludeChildBones.KeepTransforms.Distinct());
            var excludeTransforms = new List<Transform>();
            foreach (Transform transform in excludeChildBones.transform)
            {
                if (!KeepTransforms.Contains(transform))
                {
                    excludeTransforms.Add(transform);
                }
            }
            if (excludeTransforms.Count == 0)
            {
                return;
            }

            var name = GameObjectUtility.GetUniqueNameForSibling(moveTo, $"{excludeChildBones.gameObject.name}_ExcludeChildBones");
            var dummyTransform = new GameObject(name).transform;
            dummyTransform.SetParent(excludeChildBones.transform, false);
            dummyTransform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            dummyTransform.localScale = Vector3.one;
            dummyTransform.SetParent(moveTo, true);

            var parentConstraint = dummyTransform.gameObject.AddComponent<ParentConstraint>();
            parentConstraint.AddSource(new ConstraintSource()
            {
                sourceTransform = excludeChildBones.transform,
                weight = 1f
            });
            parentConstraint.constraintActive = true;
            var scaleConstraint = dummyTransform.gameObject.AddComponent<ScaleConstraint>();
            scaleConstraint.AddSource(new ConstraintSource()
            {
                sourceTransform = excludeChildBones.transform,
                weight = 1f
            });
            scaleConstraint.constraintActive = true;
            
            foreach (var excludeTransform in excludeTransforms)
            {
                excludeTransform.SetParent(dummyTransform, true);
            }
        }
    }
}
