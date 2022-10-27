using System.Collections.Generic;
namespace CAH.TypeChecker
{
    public abstract class EnumType<T> : IType<T> where T : System.Enum
    {
        public abstract List<string> TypeDeclarations { get; }
        public T Read(string value)
        {
            return (T)System.Enum.Parse(typeof(T), value);
        }

        public string Write(T value)
        {
            return value.ToString(); 
        }
    }
}