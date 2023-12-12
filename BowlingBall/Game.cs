using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall
{
    public class Game
    {
        private readonly IFrameRepository frameRepository;
        private readonly IScoreCalculationStrategy calculator;
        private int currentRoll = 1;
        private const int MaxFrames = 10;
        private const int MaxPins = 10;

        public Game(IFrameRepository frameRepository, IScoreCalculationStrategy calculator)
        {
            this.calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            this.frameRepository= frameRepository ?? throw new ArgumentNullException(nameof(frameRepository));
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
            var frames = frameRepository.GetAllFrames();
            return calculator.CalculateScore(frames);
        }

        private void StartNewFrame()
        {
            frameRepository.AddFrame(new Frame());
            currentRoll = 1;
        }

        private void HandleRegularFrameRoll(int pins)
        {
            if (currentRoll == 1)
            {
                frameRepository.GetCurrentFrame().FirstRoll = pins;
                if (pins == 10) 
                {
                    frameRepository.GetCurrentFrame().SecondRoll = 0;
                    frameRepository.GetCurrentFrame().DetermineFrameType();
                    StartNewFrame();
                }
                else
                {
                    currentRoll = 2; 
                }
            }
            else
            {
                frameRepository.GetCurrentFrame().SecondRoll = pins;
                frameRepository.GetCurrentFrame().DetermineFrameType();
                StartNewFrame(); 
            }
        }

        private void HandleTenthFrameRoll(int pins)
        {
            if (currentRoll == 1)
            {
                frameRepository.GetCurrentFrame().FirstRoll = pins;
                currentRoll = 2;
            }
            else if (currentRoll == 2)
            {
                frameRepository.GetCurrentFrame().SecondRoll = pins;
                if (pins == 10 || frameRepository.GetCurrentFrame().FirstRoll + pins == 10)
                {
                    currentRoll = 3;
                }
            }
            else
            {
                frameRepository.GetCurrentFrame().ExtraRoll = pins;
            }
        }

        private bool IsTenthFrame()
        {
            return frameRepository.GetAllFrames().Count == MaxFrames;
        }

        private void ValidatePins(int pins)
        {
            if (pins < 0 || pins > MaxPins)
            {
                throw new ArgumentException("Pins must be between 0 and 10.");
            }
            if (!IsTenthFrame() && (currentRoll == 2 && frameRepository.GetCurrentFrame().FirstRoll + pins > MaxPins))
            {
                throw new ArgumentException("Total pins in a frame cannot exceed 10.");
            }
        }
    }
}
