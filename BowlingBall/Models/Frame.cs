using System;
using BowlingBall.Enums;

namespace BowlingBall.Models
{
    public class Frame
    {
        public int FirstRoll { get; private set; }
        public int SecondRoll { get; private set; }
        public int ExtraRoll { get; private set; }
        public FrameType Type { get; private set; }

        public Frame(int firstRoll, int secondRoll, int extraRoll = 0)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            ExtraRoll = extraRoll;
            DetermineFrameType();
        }

        private void DetermineFrameType()
        {
            if (FirstRoll == 10)
            {
                Type = FrameType.Strike;
            }
            else if (FirstRoll + SecondRoll == 10)
            {
                Type = FrameType.Spare;
            }
            else
            {
                Type = FrameType.Normal;
            }
        }
    }
}

