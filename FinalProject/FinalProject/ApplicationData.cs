using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ApplicationData
    {
        public static void createFileIfNotPresent(string file_name)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            if (!store.FileExists(file_name)) { store.CreateFile(file_name); }
        }

        public static void writeToStoredFile(string file_name, string text)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(file_name, FileMode.Append, store))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(text);
                }
            }
        }

        public static string readFromStoredFile(string file_name)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(file_name, FileMode.Open, store))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
