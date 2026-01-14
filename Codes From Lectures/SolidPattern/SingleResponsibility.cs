using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPattern
{
    public class InfoClass
    {
        DataBaseProvider dataBaseProvider = new DataBaseProvider();
        public void GetInfo()
        {
            dataBaseProvider.GetInfo();
        }

        public void SaveInfo(string info)
        {
            dataBaseProvider.SetInfo(info);
        }
    }

    public class InfoClass2
    {
        public void GetInfo()
        {
            MyLog.GetInfo();
        }

        public void SaveInfo(string info)
        {
            MyLog.SetInfo(info);
        }
    }

    public static class MyLog
    {
        static DataBaseProvider dataBaseProvider = new DataBaseProvider();
        static FileProvider fileProvider = new FileProvider();
        public static string GetInfo()
        {
            dataBaseProvider.GetInfo();
        }
        public static void SetInfo(string info)
        {
            dataBaseProvider.SetInfo(info);
        }
    }

    public class DataBaseProvider
    {
        private static string _info = "George";
        public static string GetInfo()
        {
            dataBaseProvider.GetInfo();
        }
        public static void SetInfo(string info)
        {
            dataBaseProvider.SetInfo(info);
        }
    }

    public class FileProvider
    {
        private static string _info = "George";
        public static string GetInfo()
        {
            fileProvider.GetInfo();
        }
        public static void SetInfo(string info)
        {
            fileProvider.SetInfo(info);
        }
    }
}
