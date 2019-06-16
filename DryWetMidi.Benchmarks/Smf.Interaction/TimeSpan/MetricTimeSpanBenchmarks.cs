﻿using System;
using BenchmarkDotNet.Attributes;
using Melanchall.DryWetMidi.Smf.Interaction;
using NUnit.Framework;

namespace Melanchall.DryWetMidi.Benchmarks.Smf.Interaction
{
    [TestFixture]
    public sealed class MetricTimeSpanBenchmarks : BenchmarkTest
    {
        #region Nested classes

        [ClrJob]
        public class Benchmarks : TimeSpanBenchmarks<MetricTimeSpan>
        {
            #region Constants

            private static readonly Tempo FirstTempo = Tempo.FromBeatsPerMinute(130);
            private static readonly Tempo SecondTempo = Tempo.FromBeatsPerMinute(90);

            #endregion

            #region Overrides

            public override TempoMap TempoMap { get; } = GetTempoMap();

            #endregion

            #region Methods

            private static TempoMap GetTempoMap()
            {
                var changeTempoOffset = 5 * TimeOffset - 1;
                var maxTime = Math.Max((TimesCount - 1) * TimeOffset, (TimesCount - 1) * TimeOffset + Length);

                bool firstTempo = true;

                using (var tempoMapManager = new TempoMapManager())
                {
                    var time = 0L;

                    while (time < maxTime)
                    {
                        tempoMapManager.SetTempo(time, firstTempo ? FirstTempo : SecondTempo);

                        firstTempo = !firstTempo;
                        time += changeTempoOffset;
                    }

                    return tempoMapManager.TempoMap;
                }
            }

            #endregion
        }

        #endregion

        #region Test methods

        [Test]
        [Description("Benchmark metric time/length conversion.")]
        public void ConvertMetricTimeSpan()
        {
            RunBenchmarks<Benchmarks>();
        }

        #endregion
    }
}
