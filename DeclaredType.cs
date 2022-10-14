using System;
using System.Collections.Generic;
using System.Reflection;
using UGS.Runtime.Core.Types;

namespace UGS.Runtime.Core
{
    public class DeclaredType
    {
        private readonly PropertyInfo Declares;
        public readonly Func<object, object> Read;
        public readonly MethodInfo ReadMethodInfo;
        public readonly IType Type;
        public readonly Func<object, object> Write;

        public DeclaredType(IType type)
        {
            Type = type;
            ReadMethodInfo = type.GetType().GetMethod("Read");
            Read = value =>
            {
                var obj = ReadMethodInfo?.Invoke(Type, new[] { value });
                return obj;
            };
            Write = null;
            Declares = type.GetType().GetProperty("TypeDeclarations");
        }
         
        public Type BaseType => ReadMethodInfo.ReturnType;

        public bool IsEnum()
        {
            return BaseType.IsEnum;
        }

        public List<string> GetDeclares()
        {
            return Declares.GetValue(Type) as List<string>;
        }
    }
}