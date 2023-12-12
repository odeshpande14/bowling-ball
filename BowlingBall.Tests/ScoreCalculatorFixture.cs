﻿using BowlingBall.Models;
using BowlingBall.Services;

namespace BowlingBall.Tests
{
    [TestClass]
    public class ScoreCalculatorFixture
    {
        [TestMethod]
        public void CalculateScore_WithNormalFrames_ShouldReturnCorrectTotalScore()
        {
            var frames = new List<Frame>
            {
                new Frame(1, 2), // 1+2 = 3
                new Frame(1, 2), // 3+1+2 = 6
                new Frame(1, 2), // 6+1+2 = 9
                new Frame(1, 2), // 9+1+2 = 12
                new Frame(1, 2), // 12+1+2 = 15
                new Frame(1, 2), // 15+1+2 = 18
                new Frame(1, 2), // 18+1+2 = 21
                new Frame(1, 2), // 21+1+2 = 24
                new Frame(1, 2), // 24+1+2 = 27
                new Frame(1, 2), // 27+1+2 = 30
            };
            var calculator = new ScoreCalculator();
            int score = calculator.CalculateScore(frames);
            Assert.AreEqual(30, score);
        }

        [TestMethod]
        public void CalculateScore_WithSpare_ShouldIncludeSpareBonus_Basic()
        {
            var frames = new List<Frame>
            {
                new Frame(7, 3), // 7+3+4(B) = 14
                new Frame(4, 2), // 14+4=2 = 20
                new Frame(1, 1), // 20+1=1 = 22
                new Frame(1, 1), // 22+1=1 = 24
                new Frame(1, 1), // 24+1=1 = 26
                new Frame(1, 1), // 26+1=1 = 28
                new Frame(1, 1), // 28+1=1 = 30
                new Frame(1, 1), // 30+1=1 = 32
                new Frame(1, 1), // 32+1=1 = 34
                new Frame(1, 1), // 34+1=1 = 36
            };

            var calculator = new ScoreCalculator();
            int score = calculator.CalculateScore(frames);
            Assert.AreEqual(36, score); 
        }

        [TestMethod]
        public void CalculateScore_WithSpare_ShouldIncludeSpareBonus_Multiple()
        {
            var frames = new List<Frame>
            {
                new Frame(7, 3), // 7+3+4(B) = 14
                new Frame(4, 2), // 14+4=2 = 20
                new Frame(1, 1), // 20+1=1 = 22
                new Frame(1, 1), // 22+1=1 = 24
                new Frame(6, 4), // 24+6+4+5(B) = 39
                new Frame(5, 5), // 39+5+5+1(B) = 50
                new Frame(1, 1), // 50+1+1 = 52
                new Frame(1, 1), // 52+1+1 = 54
                new Frame(1, 1), // 54+1+1 = 56
                new Frame(1, 1), // 56+1+1 = 58
            };

            var calculator = new ScoreCalculator();
            int score = calculator.CalculateScore(frames);
            Assert.AreEqual(58, score);
        }
    }
}

