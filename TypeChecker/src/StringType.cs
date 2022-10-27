using System;
using System.Collections.Generic;  

namespace CAH.TypeChecker
{
    internal class StringType : IType<string>
    {
        public List<string> TypeDeclarations => new List<string>() { "String", "Text" };




        public string Read(string value)
        {
            try
            {
                return value;
            }
            catch (Exception err)
            { 
                throw err;
            }
        }

        public string Write(string value)
        {
            return value;
        }
    }
}