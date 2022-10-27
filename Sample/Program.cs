using System;
using System.Collections.Generic;
using System.Linq;
using CAH.TypeChecker;
namespace Sample
{

  public enum GameState
  {
    Playing,
    End,
    Something
  }
  public class CustomEnum : EnumType<GameState>
  {
    public override List<string> TypeDeclarations => new List<string>() { "GameState" };
  }

  public struct Vector3
  {
    public float x, y, z;
    public Vector3(float x, float y, float z)
    {
      this.x = x; this.y = y; this.z = z;
    }

    public override string ToString()
    {
      return $"({x},{y},{z})";
    }
  }

    public class Vector3Type : IType<Vector3>
  {
    public List<string> TypeDeclarations => new List<string>() { "Vector3", "Vec3" };
    public Vector3 Read(string value)
    {
      var vec3 = value.Split(",").Select(int.Parse).ToArray();
      return new Vector3(vec3[0], vec3[1], vec3[2]);
    }

    public string Write(Vector3 value)
    {
      return $"${value.x},{value.y},{value.z}";
    }
  }

  
  class Program
  {
    static void Main(string[] args)
    {
      TypeChecker checker = new TypeChecker();
      var vector3 = checker[typeof(Vector3)].Read("1,2,3");
      var integer = checker[typeof(int)].Read("100000");
      var floating = checker[typeof(float)].Read("25.6123");
      var enumTest = checker[typeof(GameState)].Read("End");
      var enumTest2 = checker["GameState"].Read("Playing");

  
      Console.WriteLine("-- primitive --");
      Console.WriteLine(integer);
      Console.WriteLine(floating);
      Console.WriteLine("-- custom vector3 type --");
      Console.WriteLine(vector3.ToString());
      Console.WriteLine("-- enum --");
      Console.WriteLine(enumTest);
      Console.WriteLine(enumTest2);

      while (true) { }
    }
  }
}
