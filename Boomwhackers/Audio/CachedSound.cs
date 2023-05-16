using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NAudio.Wave;

namespace Boomwhackers.Audio
{
    class CachedSound
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }

        public void WriteResourceToFile(string resourceName, string fileName)
        {
            var resource = Properties.Resources.ResourceManager.GetObject(resourceName);
            // cast to memory stream
            var stream = resource as MemoryStream;
            using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(file);
            }
        }
        public CachedSound(string audioFileName)
        {
            if (audioFileName.StartsWith("resources://"))
            {
                // Make a file out of the sound
                string fileName = Path.GetTempFileName();
                // extract resource name
                string resourceName = audioFileName.Substring(12);
                WriteResourceToFile(resourceName, fileName);
                audioFileName = fileName;
            }
            using (var audioFileReader = new AudioFileReader(audioFileName))
            {
                WaveFormat = audioFileReader.WaveFormat;
                var wholeFile = new List<float>((int)(audioFileReader.Length / 4));
                var readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
                int samplesRead;
                while ((samplesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    wholeFile.AddRange(readBuffer.Take(samplesRead));
                }
                AudioData = wholeFile.ToArray();
            }

        }

        static byte[] StreamToByteArray(Stream inputStream)
        {
            if (!inputStream.CanRead)
            {
                throw new ArgumentException();
            }

            // This is optional
            if (inputStream.CanSeek)
            {
                inputStream.Seek(0, SeekOrigin.Begin);
            }

            byte[] output = new byte[inputStream.Length];
            int bytesRead = inputStream.Read(output, 0, output.Length);
            Debug.Assert(bytesRead == output.Length, "Bytes read from stream matches stream length");
            return output;
        }
    }
}