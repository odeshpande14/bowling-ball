using System;
using BowlingBall.Enums;
using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall.Services
{
	public class ScoreCalculator : IScoreCalculator
    {
        public int CalculateScore(List<Frame> frames)
        {
            int score = 0;
            for (int i = 0; i < frames.Count; i++)
            {
                var frame = frames[i];
                score += frame.FirstRoll + frame.SecondRoll;

                if (frame.Type == FrameType.Spare)
                {
                    score += CalculateSpareBonus(frames, i);
                }
                else if (frame.Type == FrameType.Strike)
                {
                    score += CalculateStrikeBonus(frames, i);
                }
            }
            return score;
        }

        private static int CalculateSpareBonus(List<Frame> frames, int frameIndex)
        {
            return frames[frameIndex + 1].FirstRoll;
        }

        private static int CalculateStrikeBonus(List<Frame> frames, int frameIndex)
        {

            int bonus = 0;
            if (frameIndex + 1 < frames.Count)
            {
                var nextFrame = frames[frameIndex + 1];
                bonus += nextFrame.FirstRoll;

                if (nextFrame.Type == FrameType.Strike)
                {
                    bonus += frameIndex + 2 < frames.Count ? frames[frameIndex + 2].FirstRoll : 0;
                }
                else
                {
                    bonus += nextFrame.SecondRoll;
                }
            }
            return bonus;
        }
    }
}

