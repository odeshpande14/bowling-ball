using BowlingBall.Interfaces;

namespace BowlingBall.Managers
{
    public class FrameManager
    {
        private readonly IFrameRepository frameRepository;
        private readonly IFrameFactory frameFactory;
        private readonly List<int> currentRolls = new();

        public FrameManager(IFrameRepository frameRepository, IFrameFactory frameFactory)
        {
            this.frameRepository = frameRepository;
            this.frameFactory = frameFactory;
        }

        public void AddRoll(int pins)
        {
            currentRolls.Add(pins);

            if (ShouldCreateNewFrame())
            {
                CreateNewFrame();
            }
            else
            {
                AddRollToCurrentFrame(pins);
            }
        }

        private void CreateNewFrame()
        {
            IFrame newFrame = frameFactory.CreateFrame(new List<int>(currentRolls), IsFinalFrame());
            frameRepository.AddFrame(newFrame);
            currentRolls.Clear();
        }

        private bool ShouldCreateNewFrame()
        {
            if (IsFinalFrame())
            {
                if (currentRolls.Count < Constants.Constants.MaxRollsPerFrame) return false;
                if (currentRolls.Count == Constants.Constants.MaxRollsPerFrame+ Constants.Constants.BonusRollsForFinalFrame) return true;
                if (currentRolls[0] == Constants.Constants.MaxPinsPerRoll || (currentRolls.Count == Constants.Constants.MaxRollsPerFrame && currentRolls.Sum() == Constants.Constants.MaxPinsPerRoll))
                {
                    return currentRolls.Count == Constants.Constants.MaxRollsPerFrame + Constants.Constants.BonusRollsForFinalFrame;
                }
                else
                {
                    return currentRolls.Count == Constants.Constants.MaxRollsPerFrame ;
                }
            }
            else
            {
                return currentRolls.Count == Constants.Constants.MaxRollsPerFrame || (currentRolls.Count == 1 && currentRolls[0] == Constants.Constants.MaxPinsPerRoll);
            }
        }


        private void AddRollToCurrentFrame(int pins)
        {
            var currentFrame = frameRepository.GetCurrentFrame();
            if (currentFrame != null && !currentFrame.IsFrameComplete())
            {
                currentFrame.AddRoll(pins);
            }
        }

        private bool IsFinalFrame()
        {
            return frameRepository.GetAllFrames().Count == Constants.Constants.MaxFramesPerGame-1;
        }


        public int CalculateScore()
        {
            List<IFrame> allFrames = frameRepository.GetAllFrames();
            return allFrames.Sum(frame => frame.CalculateScore(allFrames));
        }

        public bool IsGameComplete()
        {
            if (frameRepository.GetAllFrames().Count < Constants.Constants.MaxFramesPerGame)
            {
                return false;
            }

            IFrame lastFrame = frameRepository.GetCurrentFrame();

            if (frameRepository.GetAllFrames().Count == Constants.Constants.MaxFramesPerGame-1)
            {
                var rolls = lastFrame.GetRolls();
                if (rolls[0] == Constants.Constants.MaxPinsPerRoll || rolls.Take(Constants.Constants.MaxRollsPerFrame).Sum() == Constants.Constants.MaxPinsPerRoll) 
                {
                    return rolls.Count == Constants.Constants.MaxRollsPerFrame+Constants.Constants.BonusRollsForFinalFrame;
                }
                return rolls.Count == Constants.Constants.MaxRollsPerFrame;
            }

            return lastFrame.IsFrameComplete();
        }
    }

}

