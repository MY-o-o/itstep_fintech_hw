using BlockChain.Services;

static void Display(BlockChainService bcService)
{
    BlockChainDisplayService.DisplayBlockChain(bcService.Chain);
    BlockChainDisplayService.DisplayValidationResult(bcService.IsValid());
    Console.WriteLine(Environment.NewLine);
}

var blockChainService = new BlockChainService();

blockChainService.AddBlock("Mark sent 10 coins to John", "Mark");
blockChainService.AddBlock("John sent 5 coins to Alice", "John");
blockChainService.AddBlock("Alice sent 5 coins to Bob", "Alice");
blockChainService.AddBlock("Mark sent 5 coins to Bob", "Mark");
blockChainService.AddBlock("Bob sent 10 coins to Mark", "Bob");

Console.WriteLine("---------------------------------------------- Initial Blockchain ----------------------------------------------");
Display(blockChainService);

Console.WriteLine("---------------------------------------------- Tampered Blockchain ----------------------------------------------");
blockChainService.Chain[1].Data = "Mark sent 100 coins to John"; // Tampering with the blockchain
Display(blockChainService);

Console.WriteLine("--------------------------------------------- Validated Blockchain ---------------------------------------------");
BlockchainTamperingService.TamperWithBlockChain(blockChainService, 1);
Display(blockChainService);

Console.WriteLine("------------------------------------------- Validated Blockchain (2) -------------------------------------------");
blockChainService.Chain[4].Data = "Misha sent 5 coins to Bob";
blockChainService.Chain[4].Author = "Misha";
blockChainService.Chain[5].Data = "Bob sent 10 coins to Misha";
BlockchainTamperingService.TamperWithBlockChain(blockChainService, 4);
Display(blockChainService);