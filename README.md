# type-checker  
```cs
void Example(){
      // basic example
      
      var typeChecker = new TypeChecker(); 
      typeChecker["number"].Read("2000")_ => 2000 
      typeChecker["Integer"].Read("2000")_ => 2000
      typeChecker["Int"].Read("2000")_ => 2000
      typeChecker[typeof(int)].Read("3000") => 3000  
      typeChecker["GameState"].Read("Playing")         => GameState.Playing
      typeChecker[typeof(GameState)].Read("Something") => GameState.Something 
      
      // useful case
      
      string columns = "userName:string"
      strimg values = ["abc123", "ghost", "devil"]
      string type = columns.Trim().Split(':')[1];
      
      foreach(var value in values){
            Console.WriteLine(typeChecker[type].Read(value));
      }
      
}
```
 
