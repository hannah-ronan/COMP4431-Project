using UnityEngine;

namespace Audio
{
    /// <summary>
    ///  Audio class to play audio clips; with appropriate setting volumes
    /// </summary>
    public static class Audio
    {
        private const int DefaultVolume = 1; //max volume

        /// <summary>
        /// Retrieves the combined volume of the specified audio type and the master volume.
        /// </summary>
        /// <param name="type">the audio type</param>
        /// <returns>the combined volume, between 0 and 1</returns>
        public static float GetCombinedVolume(AudioTypes type) => GetVolume(type) * MasterVolume;

        /// <summary>
        /// Retrieves the volume setting for the specified audio type from player preferences.
        /// </summary>
        /// <param name="type">audio category</param>
        /// <returns>float between 0 and 1 representing volume</returns>
        public static float GetVolume(AudioTypes type) =>
            PlayerPrefs.GetFloat($"{type.ToString().ToLower()}_volume", DefaultVolume);

        /// <summary>
        ///  volume that controls all audio.
        /// </summary>
        public static float MasterVolume => PlayerPrefs.GetFloat("master_volume", DefaultVolume);

        public static void Play(AudioClip clip, AudioTypes type, Vector3? position = null)
        {
            if(clip == null)
                return;

            position ??= Camera.current.transform.position;
            AudioSource.PlayClipAtPoint(clip, position.Value, GetCombinedVolume(type));
        }
    }
}