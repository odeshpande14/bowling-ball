using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall
{
    public class Game
    {
        private readonly List<Frame> frames;
        private readonly IScoreCalculator calculator;
        private Frame currentFrame;
        private int currentRoll = 1;
        private const int MaxFrames = 10;
        private const int MaxPins = 10;

        public Game(IScoreCalculator calculator)
        {
            this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            frames = new List<Frame>();
            currentFrame = new Frame();
            frames.Add(currentFrame);
        }

        public void Roll(int pins)
        {
            ValidatePins(pins);
            if (IsTenthFrame())
            {
                HandleTenthFrameRoll(pins);
            }
            else
            {
                HandleRegularFrameRoll(pins);
            }
        }

        public int GetScore()
        {
            return calculator.CalculateScore(frames);
        }

        private void StartNewFrame()
        {
            currentFrame = new Frame();
            frames.Add(currentFrame);
            currentRoll = 1;
        }

        private void HandleRegularFrameRoll(int pins)
        {
            if (currentRoll == 1)
            {
                currentFrame.FirstRoll = pins;
                if (pins == 10) 
                {
                    currentFrame.SecondRoll = 0;
                    currentFrame.DetermineFrameType();
                    StartNewFrame();
                }
                else
                {
                    currentRoll = 2; 
                }
            }
            else
            {
                currentFrame.SecondRoll = pins;
                currentFrame.DetermineFrameType();
                StartNewFrame(); 
            }
        }

        private void HandleTenthFrameRoll(int pins)
        {
            if (currentRoll == 1)
            {
                currentFrame.FirstRoll = pins;
                currentRoll = 2;
            }
            else if (currentRoll == 2)
            {
                currentFrame.SecondRoll = pins;
                if (pins == 10 || currentFrame.FirstRoll + pins == 10)
                {
                    currentRoll = 3;
                }
            }
            else
            {
                currentFrame.ExtraRoll = pins;
            }
        }

        private bool IsTenthFrame()
        {
            return frames.Count == MaxFrames;
        }

        private void ValidatePins(int pins)
        {
            if (pins < 0 || pins > MaxPins)
            {
                throw new ArgumentException("Pins must be between 0 and 10.");
            }

            if (currentRoll == 2 && currentFrame.FirstRoll + pins > MaxPins)
            {
                throw new ArgumentException("Total pins in a frame cannot exceed 10.");
            }
        }
    }
}
