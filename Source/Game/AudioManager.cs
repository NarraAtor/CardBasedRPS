using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// AudioManager Script.
    /// </summary>
    public class AudioManager : Script
    {

        public AudioSource Source;
        private List<AudioClip> multiClips;
        private bool importantSpeechPlaying;

        /// <inheritdoc/>
        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update
            importantSpeechPlaying = false;
            multiClips = new List<AudioClip>();
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            // Here you can add code that needs to be called every frame

            if (Source.State != AudioSource.States.Playing && multiClips.Count > 0)
            {
                Source.Clip = multiClips[0];
                Source.Play();
                multiClips.RemoveAt(0);
            }

            if (Source.State != AudioSource.States.Playing && multiClips.Count == 0) { importantSpeechPlaying = false; }

        }

        public void PlaySound(AudioClip soundClip)
        {
            if (!importantSpeechPlaying)
            {
                Source.Stop();
                Source.Clip = soundClip;
                Source.Play();
            }
            
        }

        public void PlaySoundContinuously(List<AudioClip> soundClips)
        {
            importantSpeechPlaying = true;
            multiClips = soundClips;
        }
    }
}
