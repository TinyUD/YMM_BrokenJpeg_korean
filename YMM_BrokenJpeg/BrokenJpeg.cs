using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace YMM_BrokenJpeg
{
    [VideoEffect("Broken Jpeg", ["가공"], [], IsAviUtlSupported = false)]
    public class BrokenJpeg : VideoEffectBase
    {
        [Display(Name = "압축 품질", Description = "JPEG로 압축할 때의 품질")]
        [AnimationSlider("F0", "", 0.0, 100.0)]
        public Animation CompressQuality { get; } = new Animation(50.0, 0.0, 100.0);

        SubSamplingType subSamplingType = SubSamplingType.YCbCr444;
        [Display(Name = "서브샘플링", Description = "압축 시 실시하는 샘플링의 종류")]
        [EnumComboBox]
        public SubSamplingType SubSamplingType
        {
            get => subSamplingType;
            set => Set(ref subSamplingType, value);
        }

        Color backgroundColor = Colors.Black;
        [Display(Name = "배경색", Description = "배경색")]
        [ColorPicker]
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                Set(ref backgroundColor, value);
            }
        }

        [Display(GroupName = "화면 글리치", AutoGenerateField = true)]
        public ScanPropertyGroup Scan { get; } = new ScanPropertyGroup();

        [Display(GroupName = "양자화 테이블(휘도)의 파손", AutoGenerateField = true)]
        public QuantizeTablePropertyGroup LuminanceQuantizeTable { get; } = new QuantizeTablePropertyGroup();

        [Display(GroupName = "양자화 테이블(색차) 파손", AutoGenerateField = true)]
        public QuantizeTablePropertyGroup ChrominanceQuantizeTable { get; } = new QuantizeTablePropertyGroup();

        public override string Label => "Broken Jpeg";

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return [];
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new BrokenJpegProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables()
        {
            return [CompressQuality, Scan, LuminanceQuantizeTable, ChrominanceQuantizeTable];
        }
    }
}
