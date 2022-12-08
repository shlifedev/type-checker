# type-checker  
```cs
void Example(){
      var typeChecker = new TypeChecker(); 
      typeChecker["number"].Read("2000")_ => 2000 
      typeChecker["Integer"].Read("2000")_ => 2000
      typeChecker["Int"].Read("2000")_ => 2000
      typeChecker[typeof(int)].Read("3000") => 3000  
      typeChecker["GameState"].Read("Playing")         => GameState.Playing
      typeChecker[typeof(GameState)].Read("Something") => GameState.Something 
}
```
 
