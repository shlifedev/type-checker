using System;
using System.Collections.Generic;
namespace CAH.TypeChecker
{
    internal class FloatType : IType<float>
    {
        public List<string> TypeDeclarations => new List<string>() { "Float" };



        public float Read(string value)
        {
            try
            {
                return float.Parse(value);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public string Write(float value)
        {
            return value.ToString();
        }
    }
}