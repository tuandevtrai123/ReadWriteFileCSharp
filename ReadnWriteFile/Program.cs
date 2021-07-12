using System;
using System.Linq;
// Doc ghi file dung system.io
using System.IO;
using ReadnWriteFile.Entities;
using System.Collections.Generic;

namespace ReadnWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            //Demo2();
            //Demo3();
            //Demo4();
            //Demo5();
            //Demo6();
            //Demo7();
            //Demo8();
            //Demo9();
            //Demo10();
            //Demo11();
        }

        // Write file data

        static void Demo11()
        {
            using ( var streamWriter = new StreamWriter("/Users/nguyengiatuan/Documents/container/f.txt"))
            {
                streamWriter.WriteLine("ABC");
                streamWriter.WriteLine("XYZ");
                streamWriter.WriteLine("POW");
                streamWriter.WriteLine("NAH");
            }
        }

        static void Demo10()
        {
            // Ghi de len toan bo text
            File.WriteAllText("/Users/nguyengiatuan/Documents/container/e.txt","XYZ");

            // Ghi noi lien sau len toan bo text
            File.AppendAllText("/Users/nguyengiatuan/Documents/container/e.txt"," ABC");
        }

        // Read file data

        static void Demo9()
        {
            var products = ImportCSV("/Users/nguyengiatuan/Documents/container/product.csv");
            Console.WriteLine("So luong san pham: "+products.Count);

            products.ForEach(i =>
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine("\t================");
            });
        }

        static List<Product> ImportCSV(string fileName)
        {
            try
            {
                var products = new List<Product>();
                using (var streamReader = new StreamReader(fileName))
                {
                    var line = "";

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var result = line.Trim().Split(new char[] {','});
                        products.Add(new Product
                        {
                            Id=result[0].Trim(),
                            Name=result[1].Trim(),
                            Price=double.Parse(result[2].Trim()),
                            Quantity= int.Parse(result[3].Trim())
                        }); 
                    }
                }
                return products;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // neu dung using thi khong can dong streamReader
        static void Demo8()
        {
            using (var streamReader = new StreamReader("/Users/nguyengiatuan/Documents/container/d.txt"))
            {  
                var line = "";

                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void Demo7()
        {
            var streamReader = new StreamReader("/Users/nguyengiatuan/Documents/container/d.txt");
            var line = "";

            while ((line = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            streamReader.Close();
        }


        static void Demo6()
        {
            // Lay ve tung dong text
            File.ReadAllLines("/Users/nguyengiatuan/Documents/container/d.txt").ToList().ForEach(i =>
            {
                Console.WriteLine(i);
            });
        }

        static void Demo5()
        {
            // Lay ve toan bo text khong phan biet dong
            var content = File.ReadAllText("/Users/nguyengiatuan/Documents/container/a.txt");
            Console.WriteLine("Content: "+content);
        }

        static void Demo4()
        {
            var directoryInfo = new DirectoryInfo("/Users/nguyengiatuan/Documents/container");

            FileInfo[] files = directoryInfo.GetFiles();

            if(files.Length > 0)
            {
                Console.WriteLine("files quantity: "+ files.Length);
                files.ToList().ForEach(i =>
                {
                    Console.WriteLine("Name: " + i.Name);
                    Console.WriteLine("Path: " + i.FullName);
                    Console.WriteLine("Size: " + i.Length);
                    Console.WriteLine("\t===============");
                });
            }

            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            if(directoryInfos.Length>0)
            {
                Console.WriteLine("Folders: "+directoryInfos.Length);
                directoryInfos.ToList().ForEach(i =>
                {
                    Console.WriteLine("Name: "+i.Name);
                    Console.WriteLine("-----------------");
                });
            }
        }

        //folder
        static void Demo3()
        {
            var directoryInfo = new DirectoryInfo("/Users/nguyengiatuan/Documents/container/folder 1");
            Console.WriteLine("Name: "+directoryInfo.Name);
            Console.WriteLine("Path: "+directoryInfo.FullName);
        }

        // file
        static void Demo2()
        {
            var fileInfo = new FileInfo("/Users/nguyengiatuan/Documents/container/a.txt");
            Console.WriteLine("File name: "+fileInfo.Name);
            Console.WriteLine("File extension: "+fileInfo.Extension);
            Console.WriteLine("File path: "+fileInfo.FullName);
            Console.WriteLine("File size: "+fileInfo.Length);
        }

        static void Demo1()
        {
            // partial
            // student

            var student1 = new Student
            {
                Id = "st01",
                Name = "Student1"
            };

            Console.WriteLine("Id: "+student1.Id);
            Console.WriteLine("Name: "+student1.Name);
            student1.Work1();
            student1.Work2();
        }
    }
}
