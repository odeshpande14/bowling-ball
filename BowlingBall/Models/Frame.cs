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

        public Frame() { }

        public Frame(int firstRoll, int secondRoll, int extraRoll = 0)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            ExtraRoll = extraRoll;
            DetermineFrameType();
        }

        public void SetRolls(int firstRoll, int secondRoll)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
            DetermineFrameType();
        }

        public void SetFirstRoll(int pins)
        {
            FirstRoll = pins;
            if (pins == Constants.Constants.MaxPins)
            {
                Type = FrameType.Strike;
            }
        }

        public void SetSecondRoll(int pins)
        {
            SecondRoll = pins;
            DetermineFrameType();
        }

        public void SetBonusRoll(int pins)
        {
            ExtraRoll = pins;
        }

        private void DetermineFrameType()
        {
            if (FirstRoll == Constants.Constants.MaxPins)
            {
                Type = FrameType.Strike;
            }
            else if (FirstRoll + SecondRoll == Constants.Constants.MaxPins)
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

