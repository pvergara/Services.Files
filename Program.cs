namespace Services.Files
{
    internal abstract class Program
    {
        private static void Main()
        {
            var separator = Path.DirectorySeparatorChar.ToString();
            var directory = Environment.GetEnvironmentVariable("homepath");
            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                directory = Environment.GetEnvironmentVariable("HOME");
            }

            var fullName = directory + separator + "iagoFile.txt";

            StreamWriter streamWriter;
            using (streamWriter = new StreamWriter(fullName))
            {
                for (var i = 1; i <= 10; i++)
                {
                    streamWriter.Write("{0,-2}", i);
                }
                streamWriter.WriteLine();
                for (var i = 1; i <= 10; i++)
                {
                    streamWriter.WriteLine($"Iago: {i,3}");
                }
            }

            var person = new Person
            {
                Name = "Mr. Potato",
                Age = 33
            };

            using (var bwp = new PersonBinaryWriter(new FileStream(directory + separator + "people.dat", FileMode.Create)))
            {
                bwp.Write(person);
            }

            Person person2;
            using (var brp = new PersonBinaryReader(new FileStream(directory + separator + "people.dat", FileMode.Open)))
            {
                person2 = brp.Read();
            }
            Console.WriteLine(person2.Name + " " + person2.Age);

        }
    }
}