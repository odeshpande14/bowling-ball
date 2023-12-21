namespace BowlingBall.Interfaces
{
    public interface IFrame
    {
        void AddRoll(int pins);
        bool IsFrameComplete();
        int CalculateScore(List<IFrame> frames);
        List<int> GetRolls();
    }
}

