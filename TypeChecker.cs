using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UGS.Runtime.Core.Exceptions;
using UGS.Runtime.Core.Types;
using UnityEngine;

namespace UGS.Runtime.Core
{
    public class TypeChecker 
    {
        public DeclaredType this[string key] => _declares[key];
        public DeclaredType this[Type key] => _declaresWithType[key];

        private static Dictionary<string, DeclaredType> _declares;
        private static Dictionary<Type, DeclaredType> _declaresWithType;

        private static IEnumerable<System.Type> _cached;

        private IEnumerable<System.Type> GetAllSubclassOf(System.Type parent)
        {
            if (_cached != null) return _cached;
            var type = parent;
            _cached = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return _cached;
        }



        public TypeChecker()
        {
            Initialize();
        }

        public DeclaredType GetDeclare(string key)
        {
            return _declares[key];
        }

        public DeclaredType GetDeclare(Type key)
        {
            return _declaresWithType[key];
        }


        public IReadOnlyDictionary<Type, DeclaredType> GetTypeMap() => _declaresWithType;
        public IReadOnlyDictionary<string, DeclaredType> GetDecalresMap() => _declares;



        [InternalInit]
        public void Initialize()
        {
            if (_declares != null && _declaresWithType != null)
                return;

            _declares = new Dictionary<string, DeclaredType>();
            _declaresWithType = new Dictionary<Type, DeclaredType>();
            var subclasses = GetAllSubclassOf(typeof(IType));
            foreach (var type in subclasses)
            {
                object typeReader = null; 
                if (type.IsClass && type.IsAbstract == false)
                {  
                    typeReader = Activator.CreateInstance(type); 
                    var declaredType = new DeclaredType(typeReader as IType);
                    var declareKeywords = declaredType.GetDeclares().Distinct();
                    foreach (var declamation in declareKeywords)
                    {
                        var lower = declamation.ToLower();
                        if (_declares.ContainsKey(lower))
                        {
                            throw new DuplicateDeclareException();
                            //$"<color=red>{declaredType.Type.GetType().Namespace+"."+ declaredType.Type.GetType().Name}</color>"
                            // +$" Declare Duplicated Exception :: Already Used Declare Keyword <color=yellow>{declamation}</color> " + $"in {this.declares[lower].Type.GetType().Name}");
                        }
                        else
                        {
                            _declares[lower] = declaredType;
                            _declaresWithType[declaredType.BaseType] = declaredType;
                       }
                    }

                    Debug.Log(declaredType.BaseType + $" checker loaded {declaredType.GetType()} \n declares : {string.Join(",", declaredType.GetDeclares())}");

                }
            }
        }
  
    }
}
