namespace SOA3.Models.SCM
{
    public interface ICommit
    {
        string Hash { get; }
        string Name { get; }
        string Description { get; }
        string ToString();
    }
}