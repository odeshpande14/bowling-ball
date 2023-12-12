using System;
using BowlingBall.Enums;

namespace BowlingBall.Models
{
    public class Frame
    {
        public int FirstRoll { get; private set; }
        public int SecondRoll { get; private set; }
        public FrameType Type { get; private set; }

        public Frame(int firstRoll, int secondRoll)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;

            if (FirstRoll == 10)
                Type = FrameType.Strike;
            else if (FirstRoll + SecondRoll == 10)
                Type = FrameType.Spare;
            else
                Type = FrameType.Normal;
        }
    }
}

