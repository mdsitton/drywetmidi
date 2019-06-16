﻿using System.IO;
using BenchmarkDotNet.Attributes;
using Melanchall.DryWetMidi.Smf;
using NUnit.Framework;

namespace Melanchall.DryWetMidi.Benchmarks.Smf
{
    [TestFixture]
    public class MidiFileReadBenchmarks : BenchmarkTest
    {
        #region Nested classes

        [ClrJob]
        public class Benchmarks
        {
            private const string SmallFilesDirectoryName = "Small";
            private const string MiddleFilesDirectoryName = "Middle";
            private const string LargeFilesDirectoryName = "Large";

            [Params(@"..\..\..\..\Resources\MIDI files\Valid")]
            public string FilesPath { get; set; }

            [Benchmark]
            public void Read_SingleTrack_Small()
            {
                Read(MidiFileFormat.SingleTrack, SmallFilesDirectoryName);
            }

            [Benchmark]
            public void Read_SingleTrack_Middle()
            {
                Read(MidiFileFormat.SingleTrack, MiddleFilesDirectoryName);
            }

            [Benchmark]
            public void Read_SingleTrack_Large()
            {
                Read(MidiFileFormat.SingleTrack, LargeFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiTrack_Small()
            {
                Read(MidiFileFormat.MultiTrack, SmallFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiTrack_Middle()
            {
                Read(MidiFileFormat.MultiTrack, MiddleFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiTrack_Large()
            {
                Read(MidiFileFormat.MultiTrack, LargeFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiSequence_Small()
            {
                Read(MidiFileFormat.MultiSequence, SmallFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiSequence_Middle()
            {
                Read(MidiFileFormat.MultiSequence, MiddleFilesDirectoryName);
            }

            [Benchmark]
            public void Read_MultiSequence_Large()
            {
                Read(MidiFileFormat.MultiSequence, LargeFilesDirectoryName);
            }

            private void Read(MidiFileFormat midiFileFormat, string directoryName)
            {
                Read(Path.Combine(FilesPath, midiFileFormat.ToString(), directoryName));
            }

            private static void Read(string directoryPath)
            {
                foreach (var filePath in Directory.GetFiles(directoryPath))
                {
                    MidiFile.Read(filePath);
                }
            }
        }

        #endregion

        #region Test methods

        [Test]
        [Description("Benchmark MidiFile.Read method.")]
        public void Read()
        {
            RunBenchmarks<Benchmarks>();
        }

        #endregion
    }
}
