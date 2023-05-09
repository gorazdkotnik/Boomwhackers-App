using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NAudio.Wave;

namespace Boomwhackers.Audio
{
    class CachedSound
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }
        public CachedSound(string audioFileName)
        {
            /*if (audioFileName.StartsWith("resources://"))
            {
                string resourceName = audioFileName.Substring(12);

                MemoryStream ms = new MemoryStream(StreamToByteArray(Properties.Resources.ResourceManager.GetStream(resourceName)));

                using (var waveFileReader = new WaveFileReader(ms))
                {
                    // Convert to float[] (AudioData)

                    WaveFormat = waveFileReader.WaveFormat;
                    var wholeFile = new List<float>((int)(waveFileReader.Length / 4));
                    byte[] readBuffer = new byte[waveFileReader.WaveFormat.SampleRate * waveFileReader.WaveFormat.Channels * 4];
                    int bytesRead;
                    while ((bytesRead = waveFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        for (int n = 0; n < bytesRead; n += 4)
                        {
                            wholeFile.Add(BitConverter.ToSingle(readBuffer, n));
                        }
                    }
                    AudioData = wholeFile.ToArray();
                }
            }
            else
            {*/
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
            /*}*/

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