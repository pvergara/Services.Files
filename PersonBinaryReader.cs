namespace Services.Files
{
    internal class PersonBinaryReader(Stream str) : BinaryReader(str)
    {
        public new Person Read()
        {
            var result = new Person
            {
                Name = this.ReadString(),
                Age = this.ReadByte()
            };
            return result;
        }
    }
}
