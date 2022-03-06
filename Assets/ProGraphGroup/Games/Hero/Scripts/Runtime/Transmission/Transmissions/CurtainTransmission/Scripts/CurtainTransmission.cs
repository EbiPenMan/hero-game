using Cysharp.Threading.Tasks;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace ProGraphGroup.Games.Hero.Transmission
{
    public class CurtainTransmission : TransmissionBase
    {
        public GameObject canvas;
        public SkeletonGraphic curtain;
        bool isComplete = false;
        public override async UniTask Show()
        {
            canvas.SetActive(true);
            isComplete = false;
            curtain.AnimationState.Complete += OnShowDone;
            curtain.AnimationState.SetAnimation(0, "close", false);
            await UniTask.WaitUntil(() => isComplete == true);
            isComplete = false;
            curtain.AnimationState.Complete -= OnShowDone;
        }

        protected void OnShowDone(TrackEntry trackEntry)
        {
            isComplete = true;
            curtain.AnimationState.SetAnimation(0, "fix", true);
        }

        public override async UniTask Hide()
        {
            isComplete = false;
            curtain.AnimationState.Complete += OnHideDone;
            curtain.AnimationState.SetAnimation(0, "open", false);
            await UniTask.WaitUntil(() => isComplete == true);
            canvas.SetActive(false);
            isComplete = false;
            curtain.AnimationState.Complete -= OnHideDone;
        }
        
        protected void OnHideDone(TrackEntry trackEntry)
        {
            isComplete = true;
        }
    }
}
