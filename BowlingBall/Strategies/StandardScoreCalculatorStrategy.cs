using BowlingBall.Enums;
using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall.Strategies
{
	public class StandardScoreCalculationStrategy : IScoreCalculationStrategy
    {
        public int CalculateScore(List<Frame> frames)
        {
            int score = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                score += CalculateFrameScore(frames[i]);

                if (i < 9)
                {
                    if (frames[i].Type == FrameType.Strike)
                    {
                        score += CalculateStrikeBonus(frames, i);
                    }
                    else if (frames[i].Type == FrameType.Spare)
                    {
                        score += CalculateSpareBonus(frames, i);
                    }
                }
            }
            return score;
        }

        private static int CalculateFrameScore(Frame frame)
        {
            return frame.FirstRoll + frame.SecondRoll + frame.ExtraRoll;
        }

        private static int CalculateStrikeBonus(List<Frame> frames, int frameIndex)
        {
            int bonus = 0;

            if (frameIndex + 1 < frames.Count)
            {
                bonus += frames[frameIndex + 1].FirstRoll;

                if (frames[frameIndex + 1].Type == FrameType.Strike)
                {
                    if (frameIndex + 2 < frames.Count)
                    {
                        bonus += frames[frameIndex + 2].FirstRoll;
                    }
                    else
                    {
                        bonus += frames[frameIndex + 1].SecondRoll;
                    }
                }
                else
                {
                    bonus += frames[frameIndex + 1].SecondRoll;
                }
            }

            return bonus;
        }

        private static int CalculateSpareBonus(List<Frame> frames, int frameIndex)
        {
            return frameIndex + 1 < frames.Count ? frames[frameIndex + 1].FirstRoll : 0;
        }
    }
}

