using Audio;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Options
{
    /// <summary>
    /// Options class to handle the options menu.
    /// </summary>
    public class Options: MonoBehaviour
    {
        private UIDocument UiDocument { get; set; }

        private SliderInt MasterVolumeSlider { get; set; }
        private Label LblMasterVolume { get; set; }
        private SliderInt MusicVolumeSlider { get; set; }
        private Label LblMusicVolume { get; set; }
        private SliderInt SfxVolumeSlider { get; set; }
        private Label LblSfxVolume { get; set; }

        // Start is called before the first frame update
        private void OnEnable()
        {
            UiDocument = GetComponent<UIDocument>();
            var root = UiDocument.rootVisualElement;
            MasterVolumeSlider = root.Q<SliderInt>("master_volume");
            LblMasterVolume = root.Q<Label>("lbl_master_volume");
            MusicVolumeSlider = root.Q<SliderInt>("bgMusic_volume");
            LblMusicVolume = root.Q<Label>("lbl_bgMusic_volume");
            SfxVolumeSlider = root.Q<SliderInt>("sfx_volume");
            LblSfxVolume = root.Q<Label>("lbl_sfx_volume");

            MasterVolumeSlider.RegisterCallback<ChangeEvent<int>, Label>(OnChangeHandler, LblMasterVolume);
            MusicVolumeSlider.RegisterCallback<ChangeEvent<int>, Label>(OnChangeHandler, LblMusicVolume);
            SfxVolumeSlider.RegisterCallback<ChangeEvent<int>, Label>(OnChangeHandler, LblSfxVolume);

            var masterVolume = PlayerPrefs.GetFloat("master_volume", 1);
            var musicVolume = PlayerPrefs.GetFloat("bgmusic_volume", .1f);
            var sfxVolume = PlayerPrefs.GetFloat("sfx_volume", 1);

            MasterVolumeSlider.value = (int)(masterVolume * 100);
            MusicVolumeSlider.value = (int)(musicVolume * 100);
            SfxVolumeSlider.value = (int)(sfxVolume * 100);

            LblMasterVolume.text = $"{masterVolume}%";
            LblMusicVolume.text = $"{musicVolume}%";
            LblSfxVolume.text = $"{sfxVolume}%";
        }

        private static void OnChangeHandler(ChangeEvent<int> @event, Label label)
        {
            var value = @event.newValue / 100f;
            label.text = $"{value}%"; 
            //? remove the "lbl_" prefix and convert to lowercase
            var optionName = label.name.Remove(0, 4).ToLower();
            PlayerPrefs.SetFloat(optionName, value);

            if(optionName == "sfx_volume")
                return;

            var bgMusic = GameObject.Find("BG Music").GetComponent<AudioSource>();
            bgMusic.volume = Audio.Audio.GetCombinedVolume(AudioTypes.BgMusic);
        }
    }
}