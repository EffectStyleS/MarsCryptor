using System.Security.Cryptography;
using System.Text;
using ProtectInf3;

const string key = "alphabeta9000";

var cryptor = new MarsCryptor();

cryptor.Key = ByteUintConverter.ConvertToUint(SHA384.HashData(Encoding.ASCII.GetBytes(key)));

var dataToEncrypt = File.ReadAllBytes("plain.txt");
var encrypted = cryptor.Encrypt(ByteUintConverter.ConvertToUint(dataToEncrypt));
File.WriteAllBytes("encryption.txt", ByteUintConverter.ConvertToBytes(encrypted));

var dataToDecrypt = File.ReadAllBytes("encryption.txt");
var decrypted = cryptor.Decrypt(ByteUintConverter.ConvertToUint(dataToDecrypt));
File.WriteAllBytes("decryption.txt", ByteUintConverter.ConvertToBytes(decrypted));