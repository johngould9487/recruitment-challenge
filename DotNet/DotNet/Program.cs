using System.Threading.Tasks;

namespace DotNet
{
    public class Program
    {
        static void Main()
        {
            Task winner = new PairsGame().Assign(new Player[]
            {
                new Player("John"),
                new Player("Muna")
            }).Shuffle().Start();

        }
    }
}
