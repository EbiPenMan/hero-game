using Cysharp.Threading.Tasks;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace ProGraphGroup.Games.Hero.Transmission
{
    public class TreeTransmission : TransmissionBase
    {
        public GameObject canvas;
        public SkeletonGraphic tree;
        bool isComplete = false;

        public override async UniTask Show()
        {
            canvas.SetActive(true);
            isComplete = false;
            tree.AnimationState.SetAnimation(0, "close", false);
            tree.AnimationState.Complete += OnShowDone;
            await UniTask.WaitUntil(() => isComplete == true);
            isComplete = false;
            tree.AnimationState.Complete -= OnShowDone;
        }
        
        protected void OnShowDone(TrackEntry trackEntry)
        {
            isComplete = true;
            tree.AnimationState.SetAnimation(0, "fix", true);
        }

        public override async UniTask Hide()
        {
            isComplete = false;
            tree.AnimationState.SetAnimation(0, "open", false);
            tree.AnimationState.Complete += OnHideDone;
            await UniTask.WaitUntil(() => isComplete == true);
            canvas.SetActive(false);
            isComplete = false;
            tree.AnimationState.Complete -= OnHideDone;
        }
        
        protected void OnHideDone(TrackEntry trackEntry)
        {
            isComplete = true;
        }
    }
}