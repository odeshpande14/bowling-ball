using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Enums;

namespace BowlingBall
{
    public class Game
    {
        private readonly IFrameRepository frameRepository;
        private readonly IScoreCalculationStrategy calculator;
        private int currentRoll = 1;

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
            var currentFrame = frameRepository.GetCurrentFrame();

            if (currentRoll == 1)
            {
                currentFrame.SetFirstRoll(pins);
                if (pins == Constants.Constants.MaxPins) 
                {
                    StartNewFrame();
                }
                else
                {
                    currentRoll = 2;
                }
            }
            else
            {
                currentFrame.SetSecondRoll(pins);
                StartNewFrame();
            }
        }

        private void HandleTenthFrameRoll(int pins)
        {
            var currentFrame = frameRepository.GetCurrentFrame();

            if (currentRoll == 1)
            {
                currentFrame.SetFirstRoll(pins);
                currentRoll = 2;
            }
            else if (currentRoll == 2)
            {
                currentFrame.SetSecondRoll(pins);
                if (currentFrame.Type == FrameType.Strike || (currentFrame.FirstRoll + pins == Constants.Constants.MaxPins))
                {
                    currentRoll = 3;
                }
                else
                {
                    StartNewFrame();
                }
            }
            else
            {
                currentFrame.SetBonusRoll(pins);
            }
        }

        private bool IsTenthFrame()
        {
            return frameRepository.GetAllFrames().Count == Constants.Constants.MaxFrames;
        }

        private void ValidatePins(int pins)
        {
            if (pins < 0 || pins > Constants.Constants.MaxPins)
            {
                throw new ArgumentException("Pins must be between 0 and 10.");
            }
            if (!IsTenthFrame() && (currentRoll == 2 && frameRepository.GetCurrentFrame().FirstRoll + pins > Constants.Constants.MaxPins))
            {
                throw new ArgumentException("Total pins in a frame cannot exceed 10.");
            }
        }
    }
}
