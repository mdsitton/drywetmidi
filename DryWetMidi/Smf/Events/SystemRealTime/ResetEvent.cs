﻿namespace Melanchall.DryWetMidi.Smf
{
    /// <summary>
    /// Represents Reset event.
    /// </summary>
    /// <remarks>
    /// A MIDI event that carries the MIDI reset message tells a MIDI device to reset itself.
    /// </remarks>
    public sealed class ResetEvent : SystemRealTimeEvent
    {
        #region Constructor

        public ResetEvent()
            : base(MidiEventType.Reset)
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Clones event by creating a copy of it.
        /// </summary>
        /// <returns>Copy of the event.</returns>
        protected override MidiEvent CloneEvent()
        {
            return new ResetEvent();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return "Reset";
        }

        #endregion
    }
}
