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
            Type = FrameType.Normal; 
        }
    }
}

