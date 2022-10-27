using CAH.TypeChecker;

TypeChecker tChecker = new TypeChecker();


var integer  = tChecker["int"].Read(1000);
var integer2 = tChecker[typeof(int)].Read(1000); 
var integer3 = tChecker["Number"].Read(4000);

 