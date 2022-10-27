using System.Collections.Generic;

namespace CAH.TypeChecker
{
    public interface IType
    {
    } 
    public interface IType<T> : IType
    {
        /// <summary>
        ///     All Type Names Auto Convert To Lower. (Int => int), (iNT => int)
        /// </summary>
        List<string> TypeDeclarations { get; }

        T Read(string value);

        string Write(T value);
    }
}