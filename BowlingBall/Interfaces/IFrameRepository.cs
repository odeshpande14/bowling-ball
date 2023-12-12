using BowlingBall.Models;

namespace BowlingBall.Interfaces
{
	public interface IFrameRepository
	{
        void AddFrame(Frame frame);
        List<Frame> GetAllFrames();
        Frame GetCurrentFrame();
        void Clear();
    }
}

