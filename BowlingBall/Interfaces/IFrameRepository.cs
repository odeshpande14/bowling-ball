namespace BowlingBall.Interfaces
{
	public interface IFrameRepository
	{
        void AddFrame(IFrame frame);
        IFrame GetCurrentFrame();
        List<IFrame> GetAllFrames();
    }
}

