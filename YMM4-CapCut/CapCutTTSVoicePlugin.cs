using CapCutTTSVoicePlugin;
using YukkuriMovieMaker.Plugin.Voice;

namespace CapCutTTSVoicePlugin {
    public class CapCutTTSVoicePlugin : IVoicePlugin {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "CapCutTTS";

        /// <summary>
        /// 声質一覧
        /// IVoiceSpeakerのインスタンスは毎回作成しても良い（キャッシュする必要はない）
        /// 呼び出しごとに増減しても良い
        /// </summary>
        public IEnumerable<IVoiceSpeaker> Voices => CapCutTTSVoiceSettings.Default.Speakers.Select(x => new CapCutTTSVoiceSpeaker(x));

        /// <summary>
        /// VoicesをUpdateVoicesAsync()で更新可能な場合はtrue。固定の場合はfalse。
        /// </summary>
        public bool CanUpdateVoices => true;

        /// <summary>
        /// Voicesのキャッシュが作成されている場合はtrue。作成されていない場合はfalse。
        /// falseの場合、YMM4起動時にUpdateVoicesAsync()が呼ばれる。
        /// </summary>
        public bool IsVoicesCached => CapCutTTSVoiceSettings.Default.IsCached;

        /// <summary>
        /// 音声一覧を再読込する。
        /// 再読込した結果は設定ファイルに保存し、キャッシュする必要がある。
        /// </summary>
        public Task UpdateVoicesAsync() => CapCutTTSVoiceSettings.Default.UpdateSpeakersAsync();
    }
}