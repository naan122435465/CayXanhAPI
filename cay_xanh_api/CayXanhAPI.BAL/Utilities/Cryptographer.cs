using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CayXanhAPI.BAL
{
    public class Cryptographer
    {
        #region MÃ HÓA
        /// <summary>
        /// Hàm mã hóa 2 chiều
        /// </summary>
        /// <returns></returns>
        public static string SlimEncrypt(string plainText)
        {
            string password = "echtu!t2016";
            string salt = "2016cnkkt";
            return Encrypt<System.Security.Cryptography.AesManaged>(plainText, password, salt);
        }

        /// <summary>
        /// @tinhnv: Thực hiện mã hóa dữ liệu
        /// </summary>
        /// <typeparam name="T">
        /// SymmetricAlgorithm T: Có thể là AesManaged hoặc RijndaelManaged hoặcDESCryptoServiceProvider
        /// </typeparam>
        /// <param name="clearText">Chuỗi cần mã hóa</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="salt">Giá trị khóa kết hợp (lớn hơn hoặc bằng 8 bytes)</param>
        /// <returns>Chuỗi giá trị sau khi mã hóa</returns>
        public static string Encrypt<T>(string clearText, string password, string salt)
             where T : SymmetricAlgorithm, new()
        {
            try
            {
                if (clearText == "")
                    throw new Exception("Chưa xác định nội dung cần mã hóa");
                if (password == "")
                    throw new Exception("Chưa xác định mật khẩu dùng mã hóa dữ liệu");
                if (salt == "")
                    throw new Exception("Chưa xác định giá trị khóa kết hợp dùng mã hóa dữ liệu");

                DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));
                SymmetricAlgorithm algorithm = new T();
                byte[] rgbKey = rgb.GetBytes(algorithm.BlockSize >> 3);
                byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

                ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

                string result = "";
                using (MemoryStream buffer = new MemoryStream())
                {
                    using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                        {
                            writer.Write(clearText);
                        }
                    }
                    result = Convert.ToBase64String(buffer.ToArray());
                }
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// @tinhnv: Mã hóa dùng AES (Advanced Encryption Standard)
        /// (Created in 2001, it is a variant of Rijndael. 
        /// It offers all round good performance and a good level of security. 
        /// A fully managed implementation is provided by the AesManaged class. 
        /// The AesCryptoServiceProvider class provides a faster implementation calling into native code)
        /// </summary>
        /// <param name="clearText">Chuỗi cần mã hóa</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="salt">Giá trị khóa kết hợp (lớn hơn hoặc bằng 8 bytes)</param>
        /// <returns>Chuỗi sau khi mã hóa</returns>
        public static string Encrypt_AesManaged(string clearText, string password, string salt)
        {
            try
            {
                return Encrypt<AesManaged>(clearText, password, salt);
            }
            catch //(Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        ///@tinhnv: Mã hóa dùng Rijndael
        /// (Rijndael is pretty much the same algorithm as AES in that AES was born from the Rijndael,
        /// algorithm with some tweaks to the allowed block and key sizes. 
        /// You should use AES over Rijndael, but you've got to love the name Rijndael! 
        /// A fully managed implementation is provided by the class RijndaelManaged)
        /// </summary>
        /// <param name="clearText">Chuỗi cần mã hóa</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="salt">Giá trị khóa kết hợp (lớn hơn hoặc bằng 8 bytes)</param>
        /// <returns></returns>
        public static string Encrypt_RijndaelManaged(string clearText, string password, string salt)
        {
            try
            {
                return Encrypt<RijndaelManaged>(clearText, password, salt);
            }
            catch //(Exception ex)
            {
                return "";// throw ex;
            }
        }
        /// <summary>
        ///@tinhnv: Mã hóa dùng Triple DES (Data Encryption Standard)
        /// (Basically, this is the DES algorithm applied three times to remove some known flaws in the DES cipher.
        /// The TripleDESCryptoServiceProvider class provides a native implementation)
        /// </summary>
        /// <param name="clearText">Chuỗi cần mã hóa</param>
        /// <param name="password">Mật khẩu</param>
        /// <param name="salt">Giá trị khóa kết hợp (lớn hơn hoặc bằng 8 bytes)</param>
        /// <returns></returns>
        public static string Encrypt_TripleDESCryptoServiceProvider(string clearText, string password, string salt)
        {
            try
            {
                return Encrypt<TripleDESCryptoServiceProvider>(clearText, password, salt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Mã hóa xâu ký tự đơn giản
        /// </summary>
        /// <param name="Src"></param>
        /// <returns></returns>
        public static string EnCodeStr(string Src)
        {
            string Ketqua = "";
            string Day1 = "123456789QWERTYUIOPASDFGHJKLZXCVBNMghjklzxcvbnmqwertyuiopasdf";
            string Day2 = "678912345ASDFGHJKLZXCVBNMQWERTYUIOPqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < Src.Length; i++)
            {
                int pos = Day1.IndexOf(Src[i]);
                Ketqua += (pos >= 0) ? (Day2[pos]) : (Src[i]);
            }
            return Ketqua;
        }
        #endregion

        #region GIẢI MÃ
        /// <summary>
        /// Hàm giải mã trong mã hóa 2 chiều
        /// </summary>
        /// <returns></returns>
        public static string SlimDecrypt(string encryptText)
        {
            // Chưa cài đặt
            string password = "echtu!t2016";
            string salt = "2016cnkkt";
            return Decrypt<System.Security.Cryptography.AesManaged>(encryptText, password, salt);
        }

        /// <summary>
        ///@tinhnv: Giải mã chuỗi ký tự 
        /// </summary>
        /// <typeparam name="T">
        /// SymmetricAlgorithm T: Có thể là AesManaged hoặc RijndaelManaged hoặcDESCryptoServiceProvider
        /// </typeparam>
        /// <param name="encryptText">Chuỗi cần giải mã</param>
        /// <param name="password">Mật khẩu đã dùng để mã hóa</param>
        /// <param name="salt">Giá trị khóa đã dùng kết hợp</param>
        /// <returns>Chuỗi giải mã</returns>
        public static string Decrypt<T>(string encryptText, string password, string salt)
           where T : SymmetricAlgorithm, new()
        {
            try
            {
                DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

                SymmetricAlgorithm algorithm = new T();

                byte[] rgbKey = rgb.GetBytes(algorithm.BlockSize >> 3);
                byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

                ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

                string result = "";
                using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(encryptText)))
                {
                    using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        ///@tinhnv: Thực hiện giải mã (chung)
        /// </summary>
        /// <param name="encryptText">Chuỗi cần giải mã</param>
        /// <param name="password">Mật khẩu đã dùng để mã hóa</param>
        /// <param name="salt">Giá trị khóa đã kết hợp</param>
        /// <returns></returns>
        public static string Decrypt(string encryptText, string password, string salt)
        {
            string result = "";
            try
            {
                result = Decrypt<System.Security.Cryptography.AesManaged>(encryptText, password, salt);
                if (result == "")
                    result = Decrypt<System.Security.Cryptography.RijndaelManaged>(encryptText, password, salt);
                if (result == "")
                    result = Decrypt<System.Security.Cryptography.DESCryptoServiceProvider>(encryptText, password, salt);
            }
            catch// (Exception ex)
            {
                return "";
            }
            return result;
        }

        /// <summary>
        /// Giải mã xâu ký tự đơn giản
        /// </summary>
        /// <param name="Src"></param>
        /// <returns></returns>

        public static string DeCodeStr(string Src)
        {
            string Ketqua = "";
            string Day1 = "123456789QWERTYUIOPASDFGHJKLZXCVBNMghjklzxcvbnmqwertyuiopasdf";
            string Day2 = "678912345ASDFGHJKLZXCVBNMQWERTYUIOPqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < Src.Length; i++)
            {
                int pos = Day2.IndexOf(Src[i]);
                Ketqua += (pos >= 0) ? (Day1[pos]) : (Src[i]);
            }
            return Ketqua;
        }

        #endregion

        #region BĂM  
        /// <summary>
        ///@tinhnv: giải thuật băm MD5 - độ dài 128 bits
        /// </summary>
        public const string HashMethod_MD5CryptoServiceProvider = "MD5CryptoServiceProvider";
        /// <summary>
        ///@tinhnv: giải thuật băm SHA hay SHA1 - 160 bits
        /// </summary>
        public const string HashMethod_SHA1CryptoServiceProvider = "SHA1CryptoServiceProvider";
        /// <summary>
        ///@tinhnv: giải thuật băm SHA1Managed - 160 bits
        /// </summary>
        public const string HashMethod_SHA1Managed = "SHA1Managed";
        /// <summary>
        ///@tinhnv: giải thuật băm SHA256 hay SHA-256 bits
        /// </summary>
        public const string HashMethod_SHA256Managed = "SHA256Managed";
        /// <summary>
        ///@tinhnv: giải thuật băm SHA384 hay SHA-384 bits
        /// </summary>
        public const string HashMethod_SHA384Managed = "SHA384Managed";
        /// <summary>
        ///@tinhnv: giải thuật băm SHA512 hay SHA-512 bits
        /// </summary>
        public const string HashMethod_SHA512Managed = "SHA512Managed";
        /// <summary>
        ///@tinhnv: lấy về giá trị băm của một văn bản
        /// </summary>
        /// <param name="hashMethodlogy">tên giải thuật băm áp dụng (HashMethod name lớp cung cấp)</param>
        /// <param name="plainText">đoạn văn bản cần lấy giá trị băm</param>
        /// <returns></returns>
        public static string getHash(string hashMethodlogy, string plainText)
        {
            try
            {
                using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashMethodlogy))
                {
                    //chuyển kí tự thành byte[]
                    byte[] bytes = Encoding.Default.GetBytes(plainText);
                    //tạo mã băm:
                    byte[] hash = hashAlgorithm.ComputeHash(bytes);
                    return BitConverter.ToString(hash);
                }
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        ///@tinhnv: get hash code của một văn bản text (theo giải thuật mặc định)
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string getHash(string plainText)
        {
            using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA512"))
            {
                //chuyển kí tự thành byte[]
                byte[] bytes = Encoding.Default.GetBytes(plainText);
                //tạo mã băm:
                byte[] hash = hashAlgorithm.ComputeHash(bytes);
                return BitConverter.ToString(hash);
            }
        }
        #endregion
    }
}
