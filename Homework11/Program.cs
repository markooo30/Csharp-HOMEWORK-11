namespace Homework11
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    //using System.Xml;
    using Newtonsoft.Json;



    namespace Homework
    {
        internal class Program
        {

            //        Create a C# console application that serialize and deserialize objects in JSON format. To
            //do this, you can use the JsonConvert class included in the Newtonsoft.Json namespace.
            //1. First, implement the Person class with properties(Name, Surname, Age and
            //Courses). Course class has two properties(Name and Grade). Create a person
            //object with all assigned properties and minimum three courses.
            //2. Use JsonConvert.SerializeObject(p, Formatting.Indented) to serialize the person
            //object and save the resulting string in the OnePerson.json file.
            //3. Deserialize the OnePerson.json file using JsonConvert.DeserializeObject and print
            //the contents of the deserialized object to the console.
            //4. With the help of a text editor, analyze the content of the OnePerson.json file.
            static void Main(string[] args)
            {
                Person person = new Person
                {
                    Name = "Marko",
                    Surname = "Nakovski",
                    Age = 33,
                    Courses = new List<Course>
            {
                new Course { Name = "Javascript", Grade = "C" },
                new Course { Name = "Csharp", Grade = "B" },
                new Course { Name = "Kotlin", Grade = "B" }
            }

                };

                string path = "D:\\C# Advanced\\CAS 11\\HOMEWORK";

                string directory = path + "\\DirectoryFolder";

                string file = directory + "\\OnePerson.json";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    Console.WriteLine($"New folder called directory created");
                }
                if (!File.Exists(file))
                {
                    File.Create(file).Close();
                    Console.WriteLine($"New file.txt called file created");
                }

                using (StreamWriter streamwriter = new StreamWriter(file))
                {
                    string json = JsonConvert.SerializeObject(person, Formatting.Indented);
                    streamwriter.WriteLine(json);

                    Console.WriteLine("Serialized Person:");
                    Console.WriteLine(json);
                }

                using (StreamReader streamReader = new StreamReader(file))
                {
                    string jsonDeserial = streamReader.ReadToEnd();
                    Person deserializedPerson = JsonConvert.DeserializeObject<Person>(jsonDeserial);


                    Console.WriteLine($"Name: {deserializedPerson.Name}, Surname: {deserializedPerson.Surname}, Age: {deserializedPerson.Age}");
                    foreach (var course in deserializedPerson.Courses)
                    {
                        Console.WriteLine($"Course: {course.Name}, Grade: {course.Grade}");
                    }


                }


            }


            public class Course
            {
                public string Name { get; set; }
                public string Grade { get; set; }
            }

            public class Person
            {
                public string Name { get; set; }
                public string Surname { get; set; }
                public int Age { get; set; }
                public List<Course>? Courses { get; set; }
            }
        }
    }
}