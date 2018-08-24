using System;
using System.Linq;

namespace SerieList.Extras.Util.Crypt
{
    public class TokenCrypt
    {
        public static string GenerateTokenUser(TokenUserModel tokenUserModel)
        {
            byte[] createdTime = BitConverter.GetBytes(tokenUserModel.CreatedAt.ToBinary());
            byte[] stamp = Guid.Parse(tokenUserModel.SecurityStamp).ToByteArray();
            byte[] uId = BitConverter.GetBytes(tokenUserModel.IdUser);
            byte[] keepConnected = BitConverter.GetBytes(tokenUserModel.KeepConnected);
            Random rnd = new Random();
            int rand = rnd.Next(1, 300);
            byte[] randBool = BitConverter.GetBytes(rand % 2 == 0);
            byte[] randNumber = BitConverter.GetBytes(rand);
            byte[] randGuid = Guid.NewGuid().ToByteArray();
            byte[] currTime = BitConverter.GetBytes(DateTime.Now.ToBinary());
            byte[] data = new byte[createdTime.Length + stamp.Length + uId.Length + keepConnected.Length + randBool.Length + randNumber.Length + currTime.Length + randGuid.Length];

            Buffer.BlockCopy(createdTime, 0, data, 0, createdTime.Length);
            Buffer.BlockCopy(stamp, 0, data, createdTime.Length, stamp.Length);
            Buffer.BlockCopy(uId, 0, data, createdTime.Length + stamp.Length, uId.Length);
            Buffer.BlockCopy(keepConnected, 0, data, createdTime.Length + stamp.Length + uId.Length, keepConnected.Length);
            Buffer.BlockCopy(randBool, 0, data, createdTime.Length + stamp.Length + uId.Length + keepConnected.Length, randBool.Length);
            Buffer.BlockCopy(randNumber, 0, data, createdTime.Length + stamp.Length + uId.Length + keepConnected.Length + randBool.Length, randNumber.Length);
            Buffer.BlockCopy(currTime, 0, data, createdTime.Length + stamp.Length + uId.Length + keepConnected.Length + randBool.Length + randNumber.Length, currTime.Length);
            Buffer.BlockCopy(randGuid, 0, data, createdTime.Length + stamp.Length + uId.Length + keepConnected.Length + randBool.Length + randNumber.Length + currTime.Length, randGuid.Length);

            return Convert.ToBase64String(data.ToArray());
        }

        public static TokenUserModel GetTokenUserModel(string token)
        {
            var result = new TokenUserModel();

            byte[] data = Convert.FromBase64String(token);
            byte[] tokenTime = data.Take(8).ToArray();
            byte[] tokenSecurityStamp = data.Skip(8).Take(16).ToArray();
            byte[] tokenId = data.Skip(24).Take(4).ToArray();
            byte[] tokenKeep = data.Skip(28).Take(1).ToArray();
            Guid gKey = new Guid(tokenSecurityStamp);

            result.CreatedAt = DateTime.FromBinary(BitConverter.ToInt64(tokenTime, 0));
            result.SecurityStamp = gKey.ToString();
            result.IdUser = BitConverter.ToInt32(tokenId, 0);
            result.KeepConnected = BitConverter.ToBoolean(tokenKeep, 0);

            return result;
        }
    }

    public class TokenUserModel
    {
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string SecurityStamp { get; set; }
        public bool KeepConnected { get; set; }
    }
}
