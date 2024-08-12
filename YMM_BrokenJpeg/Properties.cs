using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;

namespace YMM_BrokenJpeg
{
    public class ScanPropertyGroup : Animatable
    {
        [Display(Name = "파손 개수", Description = "데이터를 깨뜨리는 부분의 수")]
        [AnimationSlider("F0", "", 0.0, 1000.0)]
        public Animation BrokenCount { get; } = new Animation(10.0, 0.0, short.MaxValue);

        [Display(Name = "파손 범위 시작", Description = "데이터 파괴 범위의 시작 위치")]
        [AnimationSlider("F0", "%", 0.0, 100.0)]
        public Animation BrokenRangeBegin { get; } = new Animation(0.0, 0.0, 100.0);

        [Display(Name = "파손 범위 종료", Description = "데이터 파괴 범위의 종료 위치")]
        [AnimationSlider("F0", "%", 0.0, 100.0)]
        public Animation BrokenRangeEnd { get; } = new Animation(100.0, 0.0, 100.0);

        [Display(Name = "랜덤 시드", Description = "랜덤 시드")]
        [AnimationSlider("F0", "", 0.0, 1000.0)]
        public Animation RandomSeed { get; } = new Animation(438.0, 0.0, int.MaxValue);

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return [BrokenCount, BrokenRangeBegin, BrokenRangeEnd, RandomSeed];
        }

        internal ScanPropertyValue GetPropertyValue(long frame, long totalFrame, int fps)
        {
            return new ScanPropertyValue(
                (int)BrokenCount.GetValue(frame, totalFrame, fps),
                BrokenRangeBegin.GetValue(frame, totalFrame, fps) * 0.01,
                BrokenRangeEnd.GetValue(frame, totalFrame, fps) * 0.01,
                (uint)RandomSeed.GetValue(frame, totalFrame, fps)
            );
        }
    }

    public class QuantizeTablePropertyGroup : Animatable
    {
        bool enabled = false;
        [Display(Name = "활성화/비활성화", Description = "양자화 테이블의 파손 여부")]
        [ToggleSlider]
        public bool Enabled
        {
            get => enabled;
            set => Set(ref enabled, value);
        }

        [Display(Name = "파손 부위", Description = "브레이킹 테이블의 위치")]
        [AnimationSlider("F0", "", 0.0, 64.0)]
        public Animation BrokenPosition { get; } = new Animation(3.0, 1.0, 64.0);

        [Display(Name = "값", Description = "양자화 테이블 값")]
        [AnimationSlider("F0", "", 0.0, 255.0)]
        public Animation ReplaceValue { get; } = new Animation(100.0, 0.0, 255.0);

        [Display(Name = "파손 부위 수", Description = "테이블을 깰 수 있는 곳의 수")]
        [AnimationSlider("F0", "", 0.0, 63.0)]
        public Animation BrokenCount { get; } = new Animation(0.0, 0.0, 63);

        [Display(Name = "최대값", Description = "테이블 값을 깨뜨릴 때 최대값")]
        [AnimationSlider("F0", "", 0.0, 255.0)]
        public Animation MaxValue { get; } = new Animation(0.0, 0.0, 255.0);

        [Display(Name = "랜덤 시드", Description = "랜덤 시드")]
        [AnimationSlider("F0", "", 0.0, 1000.0)]
        public Animation RandomSeed { get; } = new Animation(33.0, 0.0, int.MaxValue);

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return [BrokenPosition, ReplaceValue, BrokenCount, MaxValue, RandomSeed];
        }

        internal QuantizeTablePropertyValue GetPropertyValue(long frame, long totalFrame, int fps)
        {
            return new QuantizeTablePropertyValue(
                Enabled,
                (int)BrokenPosition.GetValue(frame, totalFrame, fps) - 1,
                (byte)ReplaceValue.GetValue(frame, totalFrame, fps),
                (int)BrokenCount.GetValue(frame, totalFrame, fps),
                (int)MaxValue.GetValue(frame, totalFrame, fps),
                (uint)RandomSeed.GetValue(frame, totalFrame, fps)
            );
        }
    }
}
