# type-checker
 a way of parse typed data ex ) `propertyName : type`

# How to use

## Declare for 'T' with Keyword You Want Use IType Interface
Just extends `IType<T>` interface about `T` like below.

```cs  
    class IntType : IType<int>
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
                Debug.LogError($"Failed to parse data => {value}");
                throw err;
            }
        }

        public string Write(int value)
        {
            return value.ToString();
        } 
  }
```
Even, You can declare enum parser

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


## 

## TypeChecker Initialize And Use

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
 
 
