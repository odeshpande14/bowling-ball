using System;
using BowlingBall.Enums;

namespace BowlingBall.Models
{
    public class Frame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int ExtraRoll { get; set; }
        public FrameType Type { get; private set; }

        public Frame() { }

        public Frame(int firstRoll, int secondRoll, int extraRoll = 0)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            ExtraRoll = extraRoll;
            DetermineFrameType();
        }

        public void DetermineFrameType()
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

