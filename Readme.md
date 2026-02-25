# 🚀 Flash Loan Driver - Iniciador de Transacciones (C#)

Este repositorio contiene una aplicación de consola desarrollada en C# (.NET) cuya función principal es establecer una conexión con un nodo blockchain local, autenticar una cuenta criptográfica y preparar la ejecución de un contrato inteligente previamente desplegado.

## 🛠️ Especificaciones Técnicas

El programa utiliza la biblioteca `Nethereum` para gestionar la comunicación asíncrona con la Máquina Virtual de Ethereum (EVM) en un entorno de desarrollo aislado.

El flujo de ejecución (`Program.cs`) se articula en las siguientes fases técnicas:
1.  **Conexión RPC Local:** Define e inicializa un cliente Web3 apuntando al puerto estándar de un nodo de desarrollo local (`http://127.0.0.1:8545`, como Anvil o Ganache).
2.  **Gestión de Identidad (Account):** Importa una clave privada predefinida (hardcodeada) correspondiente a la primera cuenta de prueba del nodo local. Esta cuenta se instancia a través de `Nethereum.Web3.Accounts` para permitir la firma criptográfica de transacciones.
3.  **Vinculación del Smart Contract:** El script almacena la dirección hexadecimal (`contractAddress`) donde reside el bot en la red de pruebas. Simultáneamente, define una Interfaz Binaria de Aplicación (ABI) mínima en formato JSON (`contractAbi`) que mapea exclusivamente las funciones necesarias para la interacción (ej. la recepción de un parámetro `cantidad` de tipo `uint256`).
4.  **Inicialización de Web3:** Agrupa la cuenta autenticada y el proveedor RPC en una única instancia de `Web3` lista para emitir llamadas de estado o transacciones de escritura hacia el contrato vinculado.

---

## 🏎️ Arquitectura Conceptual (Cómo entenderlo)

Una vez comprendida la mecánica de conexión, podemos visualizar el rol de este script utilizando la siguiente analogía:

* **El Conductor (Este script en C#):** Imagina que tienes un coche de alta tecnología aparcado en un circuito cerrado de pruebas. El coche por sí solo no hace nada. Este programa es el conductor que tiene la llave (la *Private Key*), sabe exactamente en qué plaza de aparcamiento está el coche (la *Contract Address*) y tiene el manual de instrucciones básico para saber qué botones pulsar en el salpicadero (el *ABI*). Su trabajo es subirse, meter la llave en el contacto y arrancar el motor para iniciar la prueba del préstamo rápido.

## 🚀 Configuración y Ejecución

Al ser un script de prueba para un entorno local, las variables de conexión se encuentran directamente en el código fuente.

1.  Asegúrate de tener un nodo local (ej. Anvil) ejecutándose en el puerto `8545`.
2.  Verifica que la variable `contractAddress` en `Program.cs` coincida con la dirección real que te devolvió la terminal al desplegar tu contrato en el nodo local.
3.  Abre la terminal en la carpeta raíz de este proyecto y ejecuta:
    ```bash
    dotnet run
    ```

---
---

# 🚀 Flash Loan Driver - Transaction Initiator (C#) [EN]

This repository contains a console application developed in C# (.NET) whose main function is to establish a connection with a local blockchain node, authenticate a cryptographic account, and prepare the execution of a previously deployed smart contract.

## 🛠️ Technical Specifications

The program utilizes the `Nethereum` library to manage asynchronous communication with the Ethereum Virtual Machine (EVM) in an isolated development environment.

The execution flow (`Program.cs`) is articulated in the following technical phases:
1.  **Local RPC Connection:** Defines and initializes a Web3 client pointing to the standard port of a local development node (`http://127.0.0.1:8545`, such as Anvil or Ganache).
2.  **Identity Management (Account):** Imports a predefined (hardcoded) private key corresponding to the first test account of the local node. This account is instantiated through `Nethereum.Web3.Accounts` to enable cryptographic transaction signing.
3.  **Smart Contract Binding:** The script stores the hexadecimal address (`contractAddress`) where the bot resides on the test network. Simultaneously, it defines a minimal Application Binary Interface (ABI) in JSON format (`contractAbi`) that maps exclusively the functions necessary for interaction (e.g., receiving an `amount` parameter of type `uint256`).
4.  **Web3 Initialization:** Groups the authenticated account and the RPC provider into a single `Web3` instance ready to emit state calls or write transactions to the bound contract.

---

## 🏎️ Conceptual Architecture (How to understand it)

Once the connection mechanics are understood, we can visualize the role of this script using the following analogy:

* **The Driver (This C# script):** Imagine you have a high-tech car parked on a closed test track. The car by itself does nothing. This program is the driver who has the key (the *Private Key*), knows exactly which parking space the car is in (the *Contract Address*), and has the basic instruction manual to know which buttons to press on the dashboard (the *ABI*). Its job is to get in, put the key in the ignition, and start the engine to initiate the flash loan test.

## 🚀 Setup & Execution

Being a test script for a local environment, the connection variables are located directly in the source code.

1.  Ensure you have a local node (e.g., Anvil) running on port `8545`.
2.  Verify that the `contractAddress` variable in `Program.cs` matches the actual address returned by the terminal when you deployed your contract on the local node.
3.  Open the terminal in the root folder of this project and run:
    ```bash
    dotnet run
    ```