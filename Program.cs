// extensions
ExtensionMethods extensionMethods = new();
extensionMethods.RunExample();

// delegates
Delegates delegates = new();
delegates.RunExample();

// closures
Closures closures = new();
closures.RunExample();

// yield
Yield y = new();
y.RunExample();

// records
Records r = new();
r.RunExample();

// solid (Liskov)
Eagle eagle = new();
Penguin penguin = new();
BirdPrinter.PrintBird(eagle);
BirdPrinter.PrintBird(penguin);
BirdPrinter.PrintFlyingBird(eagle);
BirdPrinter.PrintNonFlyingBird(penguin);