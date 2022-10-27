# type-checker 
 타입과 벨류를 포함하는 문자열에 대한 간단한 읽기 쓰기 방법을 제공합니다. 
 아래 코드는 타입체커를 이용해서 여러가지 값을 읽는 예제입니다.

```cs
void Example(){
  var checker = new TypeChecker();
  
      checker["number"].Read("2000")_ => 2000 
      checker["Integer"].Read("2000")_ => 2000
      checker["Int"].Read("2000")_ => 2000
      checker[typeof(int)].Read("3000") => 3000  
      checker["GameState"].Read("Playing")         => GameState.Playing
      checker[typeof(GameState)].Read("Something") => GameState.Something
       
}
```

# How to use

## IType<T>를 상속받기만 하면 됩니다.

타입체커가 이를 어떻게 읽고, 써야 하는지 선언만 하면 됩니다. 다음은 Vector3 값에 대한 예제입니다.

```cs

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
```
사용자 지정한 Enum은 아래와같이 추가하면 됩니다.

```cs
    public enum GameState
    { 
        Playing,
        End,
        Something
    } 
    public class CustomEnum : EnumType<GameState>
    {
        public override List<string> TypeDeclarations => new List<string>(){ "GameState"};
    }
```
 