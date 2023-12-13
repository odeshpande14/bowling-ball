using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall.Repositories
{
    public class InMemoryFrameRepository : IFrameRepository
    {
        private readonly List<Frame> frames = new();

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public List<Frame> GetAllFrames()
        {
            return new List<Frame>(frames);
        }

        public void Clear()
        {
            frames.Clear();
        }

        public Frame GetCurrentFrame()
        {
            if (!frames.Any())
            {
                AddFrame(new Frame());
            }
            return frames.Last();
        }
    }
}

