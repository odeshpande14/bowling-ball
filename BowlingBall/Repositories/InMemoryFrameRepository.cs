using BowlingBall.Interfaces;

namespace BowlingBall.Repositories
{
    public class InMemoryFrameRepository : IFrameRepository
    {
        private readonly List<IFrame> frames;

        public InMemoryFrameRepository()
        {
            frames = new List<IFrame>(); 
        }

        public void AddFrame(IFrame frame)
        {
            frames.Add(frame);
        }

        public IFrame GetCurrentFrame()
        {
            return frames.LastOrDefault();
        }

        public List<IFrame> GetAllFrames()
        {
            return new List<IFrame>(frames);
        }
    }

}

