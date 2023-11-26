namespace Services.Files
{
    internal class PersonBinaryWriter(Stream output) :  BinaryWriter(output)
    {

        public void Write(Person person)
        {
            base.Write(person.Name);
            base.Write(person.Age);
        }
    }
}
