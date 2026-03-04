<div align="center">

# 🚀 Flash Loan Driver — Transaction Initiator

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/Nethereum-3C3C3D?style=for-the-badge&logo=ethereum&logoColor=white"/>
<img src="https://img.shields.io/badge/Anvil-FFCB47?style=for-the-badge&logo=ethereum&logoColor=black"/>
<img src="https://img.shields.io/badge/EVM-3C3C3D?style=for-the-badge&logo=ethereum&logoColor=white"/>

**C# console app that connects, authenticates and fires a deployed Flash Loan smart contract**

*Local development driver — replaces manual forge commands with programmatic contract control.*

**🌍 [English](#-english-version) · 🇪🇸 [Español](#-versión-en-español)**

</div>

---

## 🇪🇸 Versión en Español

### 🏎️ La Analogía del Conductor

> Tienes un coche de alta tecnología aparcado en un circuito cerrado de pruebas. El coche por sí solo no hace nada. **Este programa es el conductor** — tiene la llave *(Private Key)*, sabe exactamente dónde está el coche *(Contract Address)* y tiene el manual de instrucciones para saber qué botones pulsar *(ABI)*. Su trabajo es subirse, meter la llave y arrancar el motor.

---

### ⚙️ Flujo de Ejecución
```
Program.cs
    │
    ├── 1. RPC Connection
    │       └── Web3 client → http://127.0.0.1:8545 (Anvil / Ganache)
    │
    ├── 2. Identity (Account)
    │       └── new Account(privateKey) → firma criptográfica habilitada
    │
    ├── 3. Smart Contract Binding
    │       ├── contractAddress → dirección del contrato desplegado
    │       └── contractAbi     → interfaz mínima JSON (funciones necesarias)
    │
    └── 4. Web3 Init
            └── new Web3(account, rpcUrl) → listo para emitir transacciones
```

---

### 🛠️ Tech Stack

| Capa | Tecnología |
|:---|:---|
| Lenguaje | C# / .NET 10.0 |
| Web3 Integration | Nethereum |
| Nodo local | Anvil (Foundry) / Ganache |
| Red objetivo | EVM local (http://127.0.0.1:8545) |

---

### 🏗️ Estructura del Proyecto
```
03_FlashLoanDriver/
├── Program.cs                  # Lógica principal del driver
├── 03_FlashLoanDriver.csproj   # Proyecto .NET
├── 03_FlashLoanDriver.sln      # Solución
└── README.md
```

---

### 🚀 Configuración y Ejecución

**1. Levantar nodo local con Anvil**
```bash
anvil
# Nodo disponible en http://127.0.0.1:8545
# Copia la primera private key que muestra en pantalla
```

**2. Desplegar tu contrato en el nodo local**
```bash
forge create FlashLoanBot \
  --constructor-args 0xTU_POOL_ADDRESS \
  --rpc-url http://127.0.0.1:8545 \
  --private-key TU_PRIVATE_KEY_DE_ANVIL
```

**3. Actualizar `Program.cs`** con la dirección del contrato desplegado
```csharp
string contractAddress = "0x_DIRECCION_QUE_TE_DIO_FORGE";
```

**4. Ejecutar el driver**
```bash
dotnet run
```

---

### 🔗 Posición en el Ecosistema DeFi

Este driver es la **fase 3** del ecosistema — el puente entre desarrollo local y producción:

| Fase | Repo | Rol |
|:---:|:---|:---|
| 1 | `Flash_Loans` | ⚡ Contrato Solidity — lógica on-chain |
| 2 | `09_ProfitBrain` | 🧠 Controlador off-chain — conecta con Mainnet |
| 3 | `03_FlashLoanDriver` *(este)* | 🚀 Driver local — pruebas en entorno aislado |
| 4 | `10_RealPriceBrain` | 📡 Radar — detecta oportunidades en tiempo real |
| 5 | `13_SniperBot` | 🎯 Sniper — captura tokens nuevos en BSC |

---

### ⚖️ Disclaimer

Este proyecto es **exclusivamente para fines educativos e investigación DeFi**. Diseñado para entornos locales de prueba — no conecta con Mainnet por defecto.

---

### 🧑‍💻 Autor

**Héctor Oviedo** — Backend Developer & DeFi Researcher

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/hectorob/)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/HEO-80)

---
---

## 🇬🇧 English Version

### 🏎️ The Driver Analogy

> You have a high-tech car parked on a closed test track. The car does nothing on its own. **This program is the driver** — it has the key *(Private Key)*, knows exactly where the car is parked *(Contract Address)*, and has the basic instruction manual to know which buttons to press *(ABI)*. Its job is to get in, put the key in the ignition, and start the engine.

---

### ⚙️ Execution Flow
```
Program.cs
    │
    ├── 1. RPC Connection
    │       └── Web3 client → http://127.0.0.1:8545 (Anvil / Ganache)
    │
    ├── 2. Identity (Account)
    │       └── new Account(privateKey) → cryptographic signing enabled
    │
    ├── 3. Smart Contract Binding
    │       ├── contractAddress → deployed contract address
    │       └── contractAbi     → minimal JSON interface (required functions)
    │
    └── 4. Web3 Init
            └── new Web3(account, rpcUrl) → ready to emit transactions
```

---

### 🛠️ Tech Stack

| Layer | Technology |
|:---|:---|
| Language | C# / .NET 10.0 |
| Web3 Integration | Nethereum |
| Local Node | Anvil (Foundry) / Ganache |
| Target Network | Local EVM (http://127.0.0.1:8545) |

---

### 🚀 Setup & Execution

**1. Start local node with Anvil**
```bash
anvil
# Node available at http://127.0.0.1:8545
# Copy the first private key shown in the output
```

**2. Deploy your contract to the local node**
```bash
forge create FlashLoanBot \
  --constructor-args 0xYOUR_POOL_ADDRESS \
  --rpc-url http://127.0.0.1:8545 \
  --private-key YOUR_ANVIL_PRIVATE_KEY
```

**3. Update `Program.cs`** with the deployed contract address
```csharp
string contractAddress = "0x_ADDRESS_RETURNED_BY_FORGE";
```

**4. Run the driver**
```bash
dotnet run
```

---

### 🔗 Position in the DeFi Ecosystem

This driver is **phase 3** — the bridge between local development and production:

| Phase | Repo | Role |
|:---:|:---|:---|
| 1 | `Flash_Loans` | ⚡ Solidity contract — on-chain logic |
| 2 | `09_ProfitBrain` | 🧠 Off-chain controller — connects to Mainnet |
| 3 | `03_FlashLoanDriver` *(this)* | 🚀 Local driver — isolated environment testing |
| 4 | `10_RealPriceBrain` | 📡 Radar — detects opportunities in real time |
| 5 | `13_SniperBot` | 🎯 Sniper — captures new tokens on BSC |

---

### ⚖️ Disclaimer

This project is for **educational and DeFi research purposes only**. Designed for local test environments — does not connect to Mainnet by default.

---

### 🧑‍💻 Author

**Héctor Oviedo** — Backend Developer & DeFi Researcher

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/hectorob/)
[![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)](https://github.com/HEO-80)

---

<div align="center">
  <sub>Built with ☕ and DeFi research · <strong>Héctor Oviedo</strong> · Zaragoza, España</sub>
</div>
