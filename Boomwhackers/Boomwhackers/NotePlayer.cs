using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Boomwhackers.Audio;
using NAudio;
using NAudio.Wave;

namespace Boomwhackers
{
    internal static class NotePlayer
    {
        static Dictionary<string, CachedSound> cachedSounds = new Dictionary<string, CachedSound>();
        static AudioPlaybackEngine engine = new AudioPlaybackEngine();
        public static void Preload(string location)
        {
            if (!cachedSounds.ContainsKey(location))
            {
                CachedSound cachedSound = new CachedSound(location);
                cachedSounds.Add(location, cachedSound);
            }
        }

        

        // Play and make sure it's preloaded
        public static void Play(string location)
        {
            Preload(location);

            engine.PlaySound(cachedSounds[location]);
        }




    }
}
