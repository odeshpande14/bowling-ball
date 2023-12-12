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
            }
            return score;
        }

        private static int CalculateSpareBonus(List<Frame> frames, int frameIndex)
        {
            return frames[frameIndex + 1].FirstRoll;
        }
    }
}

