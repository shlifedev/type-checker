# type-checker

# How to use

## Declare your types
 
`int type` read example
 
```cs  
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

## TypeChecker Initialize And Use
 var checker = new TypeChecker().Initialize();
 checker["number"].Read("2000")_ => 2000
 checker[typeof(int)].Read("3000") => 3000
 
 
