using System;
using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall.Services
{
	public class ScoreCalculator : IScoreCalculator
    {
        public int CalculateScore(List<Frame> frames)
        {
            int score = 0;
            foreach (var frame in frames)
            {
                score += frame.FirstRoll + frame.SecondRoll;
            }
            return score;
        }
    }
}

