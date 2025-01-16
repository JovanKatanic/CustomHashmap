using CsharpLeet;


//var config = ManualConfig.Create(DefaultConfig.Instance)
//            .AddDiagnoser(MemoryDiagnoser.Default);
//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);

CustomHashMapNoList<string, int> map = new CustomHashMapNoList<string, int>();
map.Put("hey", 1);
map.Put("heyooo", 1);
map.Put("heyrrrr", 2);
map.Put("heyrrrrsss", 22);

map.Remove("hey");

