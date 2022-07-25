using deals_app.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deals_app.Services
{
    class File_in_out
    {
        private readonly string path;

        public File_in_out(string path)
        {
            this.path = path;
        }
        private BindingList<todo_model> load_date()
        {
            var file_exists = File.Exists(path);
            if (!file_exists)
            {
                File.CreateText(path).Dispose();
                return new BindingList<todo_model>();
            }
            using (var reader = new StreamReader(path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<todo_model>>(fileText);
            }
        }

        public void Save_date(BindingList<todo_model> save)
        {
            using (StreamWriter write = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(save); // сериализуем наш список дел и записываем
                write.WriteLine(output);
            }
        }
    }
}
