using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace Boomwhackers
{
    internal static class NotePlayer
    {
        static WaveOutEvent outputDevice;
        static Dictionary<string, AudioFileReader> fileReaders = new Dictionary<string, AudioFileReader>();

        static void Preload(string location)
        {
            
        }




    }
}
