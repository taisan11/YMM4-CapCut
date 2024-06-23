using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Plugin.Voice;
using YukkuriMovieMaker.UndoRedo;
using YukkuriMovieMaker.Controls;

namespace CapCutTTSVoicePlugin {
    internal class CapCutTTSVoiceParameter : VoiceParameterBase {
        int speed = 0;
        int pitch = 10;
        int volume = 10;

        [Display(Name = "話速", Description = "テキストの読み上げ速度")]
        [TextBoxSlider("F0", "", -10, 10, Delay = -1)]
        [Range(-10, 10)]
        [DefaultValue(0)]
        public int Speed { get => speed; set => Set(ref speed, value); }

        [Display(Name = "ピッチ", Description = "合成された音声のピッチ")]
        [TextBoxSlider("F0", "", 0, 20, Delay = -1)]
        [Range(0, 20)]
        [DefaultValue(10)]
        public int Pitch { get => pitch; set => Set(ref pitch, value); }

        public int Volume { get => volume; set => Set(ref volume, value); }
}
}