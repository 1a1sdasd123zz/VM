﻿using System.Security.Cryptography;
using System.Text;

namespace VM.Start.Common.Helper
{
    public class MD5Provider
    {
        public static string GetMD5String(string str)
        {
            MD5 md5 = MD5.Create();
            str += "VM.!02192591";
            byte[] pws = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            string pwd = "";
            foreach (var item in pws)
            {
                pwd += item.ToString("X2");
            }
            return pwd;
        }

    }
}
