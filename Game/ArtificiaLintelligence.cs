using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    internal class ArtificiaLintelligence
    {
        readonly string[] moves;
        public ArtificiaLintelligence(string[] moves)
        {
            this.moves = moves;

            var key = new byte[128];
            var getComputerChoice = new byte[4];
            var getComputerRandomChoice = RandomNumberGenerator.Create();

            getComputerRandomChoice.GetBytes(key);
            getComputerRandomChoice.GetBytes(getComputerChoice);

            var hmac = new HMACSHA256(key);

            long computerChoice = Move(getComputerChoice);
            var hash = GetHashFromMove(computerChoice, hmac);

            Console.WriteLine("HMAC : " + (BitConverter.ToString(hash)));
            Rules rules = new Rules(computerChoice, key, moves);
        }
        public byte[] GetHashFromMove(long computerChoice, HMACSHA256 hmac) => hmac.ComputeHash(Encoding.UTF8.GetBytes(moves[computerChoice]));
        public long Move(byte[] getComputerChoice) => BitConverter.ToUInt32(getComputerChoice) % (moves.Length);
    }
}