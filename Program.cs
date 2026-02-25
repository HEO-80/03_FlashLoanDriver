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

    // 3. LA DIRECCIÓN DE TU ROBOT (Correcta según tu captura)
    static string contractAddress = "0xD01F3b6e16828628746e0C6Be4258B81572ba549"; 

    // 4. El "Mando a Distancia" (ABI simplificado)
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
            // A. Conectar
            var account = new Account(privateKey);
            var web3 = new Web3(account, rpcUrl);
            
            Console.WriteLine($"🔌 Conectado a: {rpcUrl}");
            Console.WriteLine($"👤 Operador: {account.Address.Substring(0, 10)}...");

            // B. Contrato
            var contract = web3.Eth.GetContract(contractAbi, contractAddress);
            var funcionSolicitar = contract.GetFunction("solicitarPrestamo");

            // C. Cantidad (1 Millón)
            BigInteger unMillon = BigInteger.Parse("1000000000000000000000000"); 

            Console.WriteLine($"\n💸 Disparando Préstamo Flash...");

            // D. ENVIAR Y ESPERAR
            // Usamos un límite de Gas alto (3M) para evitar fallos de estimación
            var receipt = await funcionSolicitar.SendTransactionAndWaitForReceiptAsync(
                account.Address, 
                new Nethereum.Hex.HexTypes.HexBigInteger(3000000), // Gas Limit
                new Nethereum.Hex.HexTypes.HexBigInteger(0),       // Value (ETH)
                null,                                              // Cancellation Token
                unMillon                                           // Parámetro de la función
            );

            // E. ANALIZAR EL RESULTADO REAL
            Console.WriteLine($"🔗 Hash: {receipt.TransactionHash}");

            if (receipt.Status.Value == 1)
            {
                // Status 1 = Éxito en Blockchain
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✅ ¡OPERACIÓN RENTABLE EJECUTADA!");
                Console.WriteLine("   Se pidió, se operó y se ganó dinero.");
            }
            else
            {
                // Status 0 = Fallo/Revert en Blockchain
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n🛡️ OPERACIÓN REVERTIDA (Válvula Activada)");
                Console.WriteLine("   El contrato detectó pérdidas y canceló la operación.");
                Console.WriteLine("   Tu capital está a salvo. Solo se gastó el Gas.");
            }
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // ESTE ES EL BLOQUE QUE FALTABA
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ ERROR DE CONEXIÓN O EJECUCIÓN: {ex.Message}");
            Console.ResetColor();
        }
    } 
}