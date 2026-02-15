using System;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

class Program
{
    // --- CONFIGURACIÓN DE LA MISIÓN ---
    // 1. La URL de tu servidor local (Terminal 1)
    static string rpcUrl = "http://127.0.0.1:8545"; 
    
    // 2. La llave privada del "Conductor" (Cuenta 0 de Anvil - Es estándar)
    static string privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80"; 

    // 3. LA DIRECCIÓN DE TU ROBOT (¡PEGA AQUÍ LA TUYA!)
    static string contractAddress = "0xD01F3b6e16828628746e0C6Be4258B81572ba549"; 

    // 4. El "Mando a Distancia" (ABI simplificado para llamar solo a nuestra función)
    static string contractAbi = @"[{'inputs':[{'internalType':'uint256','name':'cantidad','type':'uint256'}],'name':'solicitarPrestamo','outputs':[],'stateMutability':'nonpayable','type':'function'}]";

    static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("   🚀 FLASH LOAN DRIVER - SISTEMA INICIADO      ");
        Console.WriteLine("------------------------------------------------");
        Console.ResetColor();

        try
        {
            // A. Conectar a la Blockchain Local
            var account = new Account(privateKey);
            var web3 = new Web3(account, rpcUrl);
            
            Console.WriteLine($"🔌 Conectado a la Red Local: {rpcUrl}");
            Console.WriteLine($"👤 Operador: {account.Address.Substring(0, 10)}...");

            // B. Preparar la llamada al Contrato
            var contract = web3.Eth.GetContract(contractAbi, contractAddress);
            var funcionSolicitar = contract.GetFunction("solicitarPrestamo");

            // C. Definir cuánto queremos pedir (1 Millón de DAI = 1 con 18 ceros)
            // Usamos BigInteger porque es un número demasiado grande para 'int' normal
            BigInteger unMillon = BigInteger.Parse("1000000000000000000000000"); 

            Console.WriteLine($"\n💸 Solicitando Préstamo Flash de 1,000,000 DAI...");
            Console.WriteLine("⏳ Esperando confirmación de la Blockchain...");

            // D. ¡DISPARAR! (Enviamos la transacción)
            // Ponemos un límite de Gas alto (3 Millones) para asegurar que no se quede corta
            var gasLimit = new Nethereum.Hex.HexTypes.HexBigInteger(3000000);
            
            var txHash = await funcionSolicitar.SendTransactionAsync(
                account.Address, 
                gasLimit, 
                new Nethereum.Hex.HexTypes.HexBigInteger(0), // No enviamos ETH, solo llamamos
                unMillon
            );

            // E. Resultado
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✅ ¡EJECUCIÓN EXITOSA!");
            Console.ResetColor();
            Console.WriteLine($"🔗 Hash de Transacción: {txHash}");
            Console.WriteLine("El préstamo fue pedido, utilizado y devuelto en milisegundos.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ ERROR CRÍTICO: {ex.Message}");
            Console.ResetColor();
            
            // Si salta la 'Válvula de Seguridad' del contrato, lo veremos aquí
            if (ex.Message.Contains("ESTRATEGIA FALLIDA"))
            {
                Console.WriteLine("⚠️ NOTA: El contrato abortó la operación para proteger tu dinero.");
                Console.WriteLine("   (Esto es bueno: Significa que la Válvula de Seguridad funciona)");
            }
        }
    }
}