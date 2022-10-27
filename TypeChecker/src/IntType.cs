using System;
using System.Collections.Generic;  
namespace CAH.TypeChecker
{
    internal class IntType : IType<int>
    {
        public List<string> TypeDeclarations => new List<string>() { "Int", "Number", "Integer" };


        public int Read(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (Exception err)
            { 
                throw err;
            }
        }

        public string Write(int value)
        {
            return value.ToString();
        }
    }
}